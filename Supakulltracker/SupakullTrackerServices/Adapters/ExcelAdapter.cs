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
        public Int32 ID;
        public ExcelAccountSettings currentAccount;
        private Int32 tokenID;
        private Byte[] excelPackegInBytes;

        List<ITask> list_task = new List<ITask>();

        public ExcelAdapter(IAccountSettings account, Byte[] bytes)
        {
            currentAccount = (ExcelAccountSettings)account;
            excelPackegInBytes = bytes;
        }

        public ExcelAdapter(Byte[] bytes, Int32 tokID)
        {
            excelPackegInBytes = bytes;
            currentAccount = (ExcelAccountSettings)SettingsManager.GetAccountByTokenID(tokenID);
            tokenID = tokID;
        }

        public void RunAdapter()
        {
            ExcelPackage pck = OpenExcelFromByteArray();
            ExcelWorksheet ws = pck.Workbook.Worksheets.First();
            WorksheetToDataTable(ws);

        }
        
        private DataTable WorksheetToDataTable(ExcelWorksheet ws)
        {
            DataTable dt = new DataTable(ws.Name);
            int totalCols = ws.Dimension.End.Column;
            int totalRows = ws.Dimension.End.Row;
            int startRow = 2;
            ExcelRange wsRow;
            DataRow dr;
            foreach (var firstRowCell in ws.Cells[1, 1, 1, totalCols])
            {
                dt.Columns.Add(firstRowCell.Text);
            }

            for (int rowNum = startRow; rowNum <= totalRows; rowNum++)
            {
                wsRow = ws.Cells[rowNum, 1, rowNum, totalCols];
                
                dr = dt.NewRow();
                foreach (var cell in wsRow)
                {

                    dr[cell.Start.Column - 1] = cell.Text;
                }
                Write_list(dr);
                dt.Rows.Add(dr);
            }

            return dt;
        }

        private void Write_list(DataRow dr)
        {
            object[] array = new object[10];
            array = dr.ItemArray;

            TaskMain task = new TaskMain();

            task.TaskID =array[0].ToString();
            task.Summary = array[1].ToString();
            task.SubtaskType = array[2].ToString();
            task.Status = array[3].ToString();
            task.Priority = array[4].ToString();
            task.CreatedDate = array[5].ToString();
            task.CreatedBy = array[6].ToString();
            task.LinkToTracker = Sources.Excel;

            list_task.Add(task);

            Array.Clear(array, 0, array.Length);
        }

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

        private Boolean TryReadTasksFromFile()
        {
            RunAdapter();
            if (list_task.Count > 0)
            {
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
                using (ExcelPackage pck = new ExcelPackage())
                {
                    using (Stream stream = new MemoryStream(excelPackegInBytes))
                    {
                        pck.Load(stream);
                        return pck;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateTokenLastUpdateTime(String time)
        {
            using (ISession session  = NhibernateSessionFactory.GetSessionFactory(NhibernateSessionFactory.SessionFactoryConfiguration.Application).OpenSession())
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
            return listFile;
        }

    }
}