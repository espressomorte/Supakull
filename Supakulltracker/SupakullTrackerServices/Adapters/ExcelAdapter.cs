using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data;
using NHibernate;


namespace SupakullTrackerServices
{
    public class ExcelAdapter : IAdapter
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Int32 ID;
        public ExcelAccountSettings currentAccount;
        private Int32 tokenID;
        private Byte[] excelPackegInBytes;
        private Dictionary<String, String> parentTasks = new Dictionary<String, String>();
        List<ITask> list_task = new List<ITask>();


        public ExcelAdapter(IAccountSettings account, Byte[] bytes)
        {
            currentAccount = (ExcelAccountSettings)account;
            excelPackegInBytes = bytes;
        }

        public ExcelAdapter(Byte[] bytes, Int32 tokID)
        {
            excelPackegInBytes = bytes;
            currentAccount = (ExcelAccountSettings)SettingsManager.GetAccountByTokenID(tokID);
            tokenID = tokID;
        }

        public void RunAdapter()
        {
            ExcelPackage pck = OpenExcelFromByteArray();
            ExcelWorksheet ws = pck.Workbook.Worksheets.First();
            WorksheetToDataTable(ws);
            pck.Dispose();
        }

        private void WorksheetToDataTable(ExcelWorksheet ws)
        {
            int totalCols = ws.Dimension.End.Column;
            int totalRows = ws.Dimension.End.Row;
            int startRow = 2;
            ExcelRange wsRow;
            ExcelRange wsRowNames;
            wsRowNames = ws.Cells[1, 1, 1, totalCols];
            for (int rowNum = startRow; rowNum <= totalRows; rowNum++)
            {
                wsRow = ws.Cells[rowNum, 1, rowNum, totalCols];

                List<KeyValuePair<String, String>> oneTask = new List<KeyValuePair<String, String>>();
                for (int i = 0; i < wsRow.Columns; i++)
                {
                    String fieldName = String.Empty;
                    String fieldValue =String.Empty;
                    ExcelRangeBase fieldNameExcel = wsRowNames.ElementAtOrDefault(i);
                    ExcelRangeBase fielValueExcel = wsRow.ElementAtOrDefault(i);
                    if (fieldNameExcel != null)
                    {
                        fieldName = fieldNameExcel.GetValue<String>();

                    }
                    if (fielValueExcel != null)
                    {
                        fieldValue = fielValueExcel.GetValue<String>();
                    }

                    oneTask.Add(new KeyValuePair<String, String>(fieldName, fieldValue));
                }
                Write_list(oneTask);
            }
            CheckTasksForParents();
        }


        private void Write_list(List<KeyValuePair<String, String>> oneTask)
        {
            ExcelAccountTemplate template = currentAccount.Template.FirstOrDefault();
            if (template == null)
            {
                throw new Exception("No Template!");
            }
            TaskMain task = new TaskMain();

            task.TaskID = (from keyValue in oneTask
                           where keyValue.Key == template.TaskID
                           select keyValue.Value).SingleOrDefault<String>();

            task.Summary = (from keyValue in oneTask
                            where keyValue.Key == template.Summary
                            select keyValue.Value).SingleOrDefault<String>();

            task.SubtaskType = (from keyValue in oneTask
                                where keyValue.Key == template.SubtaskType
                                select keyValue.Value).SingleOrDefault<String>();

            task.Status = (from keyValue in oneTask
                           where keyValue.Key == template.Status
                           select keyValue.Value).SingleOrDefault<String>();

            task.Priority = (from keyValue in oneTask
                             where keyValue.Key == template.Priority
                             select keyValue.Value).SingleOrDefault<String>();

            task.CreatedDate = (from keyValue in oneTask
                                where keyValue.Key == template.CreatedDate
                                select keyValue.Value).SingleOrDefault<String>();

            task.CreatedBy = (from keyValue in oneTask
                              where keyValue.Key == template.CreatedBy
                              select keyValue.Value).SingleOrDefault<String>();

            task.Description = (from keyValue in oneTask
                                where keyValue.Key == template.Description
                                select keyValue.Value).SingleOrDefault<String>();

            task.Product = (from keyValue in oneTask
                            where keyValue.Key == template.Product
                            select keyValue.Value).SingleOrDefault<String>();

            task.Project = (from keyValue in oneTask
                            where keyValue.Key == template.Project
                            select keyValue.Value).SingleOrDefault<String>();

            task.Estimation = (from keyValue in oneTask
                               where keyValue.Key == template.Estimation
                               select keyValue.Value).SingleOrDefault<String>();

            task.TargetVersion = (from keyValue in oneTask
                                  where keyValue.Key == template.TargetVersion
                                  select keyValue.Value).SingleOrDefault<String>();

            task.Comments = (from keyValue in oneTask
                             where keyValue.Key == template.Comments
                             select keyValue.Value).SingleOrDefault<String>();

            var parentTask = (from keyValue in oneTask
                              where keyValue.Key == template.TaskParent
                              select keyValue.Value).SingleOrDefault<String>();
            if (!String.IsNullOrEmpty(parentTask))
            {
                parentTasks.Add(task.TaskID, parentTask);
            }

            var assigned = (from keyValue in oneTask
                              where keyValue.Key == template.Assigned
                              select keyValue.Value).SingleOrDefault<String>();
            if (!String.IsNullOrEmpty(assigned))
            {
                UserDAO user = UserDAO.FindUserFromDBByName(assigned);
                if (user != null)
                {
                    task.Assigned.Add(ConverterDAOtoDomain.UserDaoToUser(user));
                }
            }


            task.LinkToTracker = Sources.Excel;

            task.TokenID = tokenID;

            list_task.Add(task);
        }

        private void CheckTasksForParents()
        {
            foreach (var item in parentTasks)
            {
                ITask result = list_task.Select<ITask, ITask>(task => task).Where(task => task.TaskID == item.Value).SingleOrDefault();
                if (result != null)
                {
                    ITask taskForAsignAparent = list_task.SingleOrDefault(task => task.TaskID == item.Key);
                    taskForAsignAparent.TaskParent = result;
                }
            }
        }

        IList<User> Assigned { get; set; }

        public IList<ITask> GetAllTasks()
        {
            return list_task;
        }

        public ITask GetTask(int index)
        {
            throw new NotImplementedException();
        }

        public IAccountSettings TestAccount(IAccountSettings testAccount)
        {
            currentAccount = (ExcelAccountSettings)testAccount;

            if (currentAccount.Template.Count > 0)
            {
                currentAccount.TestResult = TryReadTasksFromFile();
                return currentAccount;
            }
            else
            {
                ExcelAccountTemplate newTemplate = new ExcelAccountTemplate();
                newTemplate.AllFieldsInFile = GetAllColumnsName(OpenExcelFromByteArray());

                if (newTemplate.AllFieldsInFile.Count > 0)
                {
                    currentAccount.TestResult = true;
                    currentAccount.Template.Add(newTemplate);
                }
                else
                {
                    currentAccount.TestResult = false;
                }

                return currentAccount;
            }


        }

        public IAdapter GetAdapter(IAccountSettings account)
        {
            throw new NotImplementedException();
        }

        private Boolean TryReadTasksFromFile()
        {
            RunAdapter();
            if (list_task.Count > 0)
            {
                try
                {
                    TaskMainDAO.SaveOrUpdateCollectionInDBWhithRollback(ConverterDomainToDAO.TaskMainToTaskMainDAO(list_task));
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private ExcelPackage OpenExcelFromByteArray()
        {
            try
            {
                ExcelPackage pck = new ExcelPackage();

                using (Stream stream = new MemoryStream(excelPackegInBytes))
                {
                    pck.Load(stream);
                    return pck;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateTokenLastUpdateTime(String time)
        {
            using (ISession session = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application).OpenSession())
            {
                ISQLQuery query = session.CreateSQLQuery(String.Format(@"UPDATE TOKEN SET VALUE = '{0}' WHERE TOKEN_ID = {1} AND KEY LIKE 'LastUpdateTime'", time, ID));
                query.ExecuteUpdate();
                session.Flush();
            }
        }

        private List<String> GetAllColumnsName(ExcelPackage packeg)
        {
            ExcelWorksheet ws = packeg.Workbook.Worksheets.First();
            List<String> listFile = new List<String>();
            DataTable dt = new DataTable(ws.Name);
            int totalCols = ws.Dimension.End.Column;
            int totalRows = ws.Dimension.End.Row;

            foreach (var firstRowCell in ws.Cells[1, 1, 1, totalCols])
            {
                listFile.Add(firstRowCell.Text);
            }
            packeg.Dispose();
            return listFile;
        }
    }
}