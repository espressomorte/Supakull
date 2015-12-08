using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supakulltracker.IssueService;
using Supakulltracker.UserProvider;
using System.IO;
using System.Configuration;
using OfficeOpenXml;
using System.Threading;
using System.Xml.Linq;

namespace Supakulltracker
{
    public class ExcelSynchronizer
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static GetTrackerServicesSoapClient services = new GetTrackerServicesSoapClient();

        private static String folderPathForSynchronization;
        private FileSystemWatcher fileWatcher;
        private List<ExcelAccountSettings> excelAccounts;
        private List<String> listOfLockedFiles;
        private AuthorizationResult currentUser;
        private Timer timerForLaterUdate;
        private static Boolean NeedUpdateAcountList;

        public ExcelSynchronizer(AuthorizationResult user)
        {
            currentUser = user;
            timerForLaterUdate = new Timer(new TimerCallback(LaterAutoUpdate), null, 30000, 30000);
            listOfLockedFiles = new List<String>();
            excelAccounts = new List<ExcelAccountSettings>();
            folderPathForSynchronization = TryOpenOrCreateFolderForUser();
            fileWatcher = CreateAndSetUpWarcher();
            UpdateExcelAccountsList();
            CheckAllTrackFiles();
        }

        private void LaterAutoUpdate(Object state)
        {
            CheckAllTrackFiles();
        }

        private void CheckAllTrackFiles()
        {
            String[] allFiles = Directory.GetFiles(folderPathForSynchronization, "*.xlsx");

            foreach (String fileNameWithPath in allFiles)
            {
                String path = Path.GetDirectoryName(fileNameWithPath);
                String name = Path.GetFileName(fileNameWithPath);
                List<ExcelAccountSettings> account;
                List<ExcelAccountToken> tokens;

                account = FindAcountAndToken(name, out tokens);
                if (account.Count > 0 && tokens.Count > 0)
                {
                    foreach (ExcelAccountToken token in tokens)
                    {
                        DateTime fileUpdateTime = File.GetLastWriteTime(String.Format(@"{0}\{1}", folderPathForSynchronization, name));
                        if (fileUpdateTime > token.LastUpdateTime)
                        {
                            FileWatcher_Changed(this, new FileSystemEventArgs(WatcherChangeTypes.Changed, folderPathForSynchronization, name));
                        }
                    }
                }
            }
        }

        private void UpdateExcelAccountsList()
        {
            List<IAccountSettings> allacc = SettingsManager.GetAllUserAccountsInSource(currentUser.AuthorizedUser.GetAllUserAccounts(), Sources.Excel);
            excelAccounts = allacc.Select<IAccountSettings, ExcelAccountSettings>(account => (ExcelAccountSettings)currentUser.AuthorizedUser.GetDetailsForAccount(account.ID)).ToList();
            NeedUpdateAcountList = false;
        }

        private FileSystemWatcher CreateAndSetUpWarcher()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            try
            {
                watcher.Path = folderPathForSynchronization;
                watcher.NotifyFilter = NotifyFilters.LastWrite
                    | NotifyFilters.FileName
                    | NotifyFilters.DirectoryName;

                watcher.Changed += FileWatcher_Changed;
                watcher.Renamed += FileWatcher_Renamed;

                watcher.Filter = "*.xlsx";
                watcher.EnableRaisingEvents = true;
            }
            catch (ArgumentException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                throw;
            }
            return watcher;
        }

        private void FileWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            FileAttributes atributes = File.GetAttributes(e.FullPath);
            if (atributes.HasFlag(FileAttributes.Directory))
            {
                ChangeFolderForSync(e.FullPath, currentUser);
                fileWatcher.Path = e.FullPath;
            }
            else
            {
                if (e.FullPath.EndsWith(".xlsx") && e.OldName != e.Name)
                {
                    List<ExcelAccountSettings> accountForChange;
                    List<ExcelAccountToken> tokensForChange;
                    accountForChange = FindAcountAndToken(e.OldName, out tokensForChange);
                    if (accountForChange.Count > 0 && tokensForChange.Count > 0)
                    {
                        foreach (ExcelAccountToken tokenForChange in tokensForChange)
                        {
                            if (e.Name != tokenForChange.TokenName)
                            {
                                tokenForChange.TokenName = e.Name;
                                SettingsManager.UpdateTokenNameForExcelInDB(tokenForChange.TokenId, e.Name);
                            }
                        }
                    }
                }
            }
        }

        private void FileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.FullPath.EndsWith(".xlsx") && !e.Name.StartsWith("~$"))
            {
                if (IsFileLocked(e.Name))
                {
                    return;
                }
                List<ExcelAccountSettings> accounts;
                List<ExcelAccountToken> tokens;
                accounts = FindAcountAndToken(e.Name, out tokens);
                if (accounts.Count > 0 && tokens.Count > 0)
                {
                    foreach (ExcelAccountToken token in tokens)
                    {
                        LockFileForUpdating(e.Name);
                        try
                        {
                            Byte[] fileInBytes = OpenExcelFileAndReturnByteArray(e.FullPath);
                            services.GetTasksFromExcel(fileInBytes, token.TokenId, DateTime.Now.ToString());
                            token.LastUpdateTime = DateTime.Now;
                        }
                        catch (Exception ex)
                        {
                            log.Info(ex.Message, ex);
                        }
                        finally
                        {
                            UnlockFileForUpdating(e.Name);
                        }
                    }
                }
            }
        }

        public static Byte[] OpenExcelFileAndReturnByteArray(String path)
        {
            Byte[] fileInBytes;
            try
            {
                using (FileStream stream = File.OpenRead(path))
                {
                    using (ExcelPackage packeg = new ExcelPackage(stream))
                    {
                        fileInBytes = packeg.GetAsByteArray();
                    }
                    if (fileInBytes != null && fileInBytes.Length > 0)
                    {
                        return fileInBytes;
                    }
                    else
                    {
                        throw new Exception("Bytearray is null!");
                    }
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Boolean IsFileLocked(String name)
        {
            if (listOfLockedFiles.Contains<String>(name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LockFileForUpdating(String name)
        {
            if (listOfLockedFiles.Contains<String>(name))
            {
                return;
            }
            else
            {
                listOfLockedFiles.Add(name);
            }
        }

        private void UnlockFileForUpdating(String name)
        {
            if (listOfLockedFiles.Contains<String>(name))
            {
                listOfLockedFiles.Remove(name);
            }
        }

        private List<ExcelAccountSettings> FindAcountAndToken(String tokentName, out List<ExcelAccountToken> tokenForChange)
        {
            if (NeedUpdateAcountList)
            {
                UpdateExcelAccountsList();
            }
            tokenForChange = new List<ExcelAccountToken>();
            List<ExcelAccountSettings> accountsList = new List<ExcelAccountSettings>();
            foreach (ExcelAccountSettings account in excelAccounts)
            {
                String name = tokentName.Trim(new Char[] { '~', '$' });
                ExcelAccountToken result = account.Tokens.SingleOrDefault(token => token.TokenName == name);
                if (result != null)
                {
                    tokenForChange.Add(result);
                    accountsList.Add(account);
                }
            }
            return accountsList;
        }

        private String TryOpenOrCreateFolderForUser()
        {
            UpdatePathToFolderFromConfigFile();
            if (Directory.Exists(folderPathForSynchronization))
            {
                return folderPathForSynchronization;
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(folderPathForSynchronization);
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    throw;
                }
                return folderPathForSynchronization;
            }
        }

        private void UpdatePathToFolderFromConfigFile()
        {
            folderPathForSynchronization = (String)ConfigurationManager.AppSettings[String.Format("FolderPathForSynchronizationFor.{0}", currentUser.AuthorizedUser.UserID.GetHashCode())];
            if (String.IsNullOrEmpty(folderPathForSynchronization))
            {
                String pathToDefaultFolder = Directory.GetCurrentDirectory();
                String nameOfDefaultFolder = ConfigurationManager.AppSettings[String.Format("DefaultFolderPathForSynchronization")].ToString();
                folderPathForSynchronization = String.Format(@"{0}\{1}", pathToDefaultFolder, nameOfDefaultFolder);
            }
        }

        public static void ChangeFolderForSync(String newPath, AuthorizationResult currentUser)
        {
            String userID = String.Format("FolderPathForSynchronizationFor.{0}", currentUser.AuthorizedUser.UserID);
            try
            {
                XDocument userSettingsFile = XDocument.Load(String.Format("{0}\\MyConfig.xml", Directory.GetCurrentDirectory()));
                XElement elementToEdit = userSettingsFile.Element(XName.Get("appSettings"));
                XElement result = (from addElment in elementToEdit.Descendants()
                                   where addElment.Attribute(XName.Get("key")).Value == userID
                                   select addElment).SingleOrDefault<XElement>();
                XElement elementForAdding = new XElement("add", new XAttribute("key", userID),
                                                          new XAttribute("value", newPath));

                if (result == null)
                {
                    elementToEdit.AddFirst(elementForAdding);
                }
                else
                {
                    result.ReplaceWith(elementForAdding);
                }
                userSettingsFile.Save("MyConfig.xml");
                folderPathForSynchronization = newPath;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return;
            }
        }


        public static void UpdateWatchibleFiles()
        {
            NeedUpdateAcountList = true;
        }
    }
}
