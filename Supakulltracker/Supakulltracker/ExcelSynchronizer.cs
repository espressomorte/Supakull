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

namespace Supakulltracker
{
    public class ExcelSynchronizer
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static GetTrackerServicesSoapClient services = new GetTrackerServicesSoapClient();

        private String folderPathForSynchronization;
        private FileSystemWatcher fileWatcher;
        private List<ExcelAccountSettings> excelAccounts;
        private AuthorizationResult currentUser;
        private Timer timerForLaterUdate;

        public ExcelSynchronizer(AuthorizationResult user)
        {
            currentUser = user;
            timerForLaterUdate = new Timer(new TimerCallback(LaterAutoUpdate),null, 60000, 60000);
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
            String[] allFiles = Directory.GetFiles(folderPathForSynchronization);
            foreach (String fileNameWithPath in allFiles)
            {
                String path = Path.GetDirectoryName(fileNameWithPath);
                String name = Path.GetFileName(fileNameWithPath);
                ExcelAccountSettings account;
                ExcelAccountToken token;
                account = FindAcountAndToken(name, out token);
                if (account != null && token != null)
                {
                    DateTime fileUpdateTime = File.GetLastWriteTime(String.Format(@"{0}\{1}", folderPathForSynchronization, name));
                    if (fileUpdateTime > token.LastUpdateTime)
                    {
                        FileWatcher_Changed(this, new FileSystemEventArgs(WatcherChangeTypes.Changed, folderPathForSynchronization, name));
                    }
                }
            }
        }

        private void UpdateExcelAccountsList()
        {
            List<IAccountSettings> allacc = SettingsManager.GetAllUserAccountsInSource(currentUser.AuthorizedUser.GetAllUserAccounts(), Sources.Excel);
            excelAccounts = allacc.Select<IAccountSettings, ExcelAccountSettings>(account => (ExcelAccountSettings)currentUser.AuthorizedUser.GetDetailsForAccount(account.ID)).ToList();
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
            if (e.FullPath.EndsWith(".xlsx") && e.OldName != e.Name)
            {
                FileAttributes atributes = File.GetAttributes(e.FullPath);
                if (atributes.HasFlag(FileAttributes.Directory))
                {
                    ChangeFolderForSync(e.FullPath, currentUser);
                    fileWatcher.Path = e.FullPath;
                }
                else
                {
                    ExcelAccountSettings accountForChange;
                    ExcelAccountToken tokenForChange;
                    accountForChange = FindAcountAndToken(e.OldName, out tokenForChange);
                    if (accountForChange != null && tokenForChange != null && e.Name != tokenForChange.TokenName)
                    {
                        tokenForChange.TokenName = e.Name;
                        if (SettingsManager.SaveOrUpdateAccount(accountForChange))
                        {
                            UpdateExcelAccountsList();
                        }

                    }
                }
            }

        }

        private void FileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.FullPath.EndsWith(".xlsx") && !e.Name.StartsWith("~$"))
            {
                ExcelAccountSettings account;
                ExcelAccountToken token;
                account = FindAcountAndToken(e.Name, out token);
                if (account != null && token != null)
                {
                    Byte[] fileInBytes;
                    try
                    {
                        using (FileStream stream = File.OpenRead(e.FullPath))
                        {
                            using (ExcelPackage packeg = new ExcelPackage(stream))
                            {
                                fileInBytes = packeg.GetAsByteArray();
                            }
                            if (fileInBytes != null && fileInBytes.Length > 0)
                            {
                                try
                                {
                                    services.GetTasksFromExcel(fileInBytes, account.ID, token.TokenId);        
                                }
                                catch (OverflowException ex)
                                {
                                    log.Error(ex);
                                    System.Windows.Forms.MessageBox.Show(String.Format("File {0} too big!", e.Name));
                                }
                                catch (Exception ex)
                                {
                                    log.Error(ex);
                                    return;
                                }
                            }
                        }
                    }
                    catch (IOException ex)
                    {
                        log.Info(ex);
                        return;
                    }
                }
                token.LastUpdateTime = DateTime.Now;
                if (SettingsManager.SaveOrUpdateAccount(account))
                {
                    UpdateExcelAccountsList();
                }
            }
        }

        private ExcelAccountSettings FindAcountAndToken(String tokentName, out ExcelAccountToken tokenForChange)
        {
            foreach (ExcelAccountSettings account in excelAccounts)
            {
                String name = tokentName.Trim(new Char[] { '~', '$' });
                ExcelAccountToken result = account.Tokens.SingleOrDefault(token => token.TokenName == name);
                if (result != null)
                {
                    tokenForChange = result;
                    return account;
                }
                else
                {
                    tokenForChange = null;
                    return null;
                }
            }
            tokenForChange = null;
            return null;

        }

        private String TryOpenOrCreateFolderForUser()
        {
            String folderPathForSynchronization = (String)ConfigurationManager.AppSettings[String.Format("FolderPathForSynchronizationFor.{0}", currentUser.AuthorizedUser.UserID.GetHashCode())];
            if (String.IsNullOrEmpty(folderPathForSynchronization))
            {
                folderPathForSynchronization = ConfigurationManager.AppSettings[String.Format("DefaultFolderPathForSynchronization")].ToString();
            }
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

        public static void ChangeFolderForSync(String newPath, AuthorizationResult currentUser)
        {
            ConfigurationManager.AppSettings.Remove(String.Format("FolderPathForSynchronizationFor.{0}", currentUser.AuthorizedUser.UserID.GetHashCode()));
            ConfigurationManager.AppSettings.Add(String.Format("FolderPathForSynchronizationFor.{0}", currentUser.AuthorizedUser.UserID.GetHashCode()), newPath);
        }

    }
}
