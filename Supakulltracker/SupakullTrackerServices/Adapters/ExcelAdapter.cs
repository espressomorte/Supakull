using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data;

namespace SupakullTrackerServices
{
    public class ExcelAdapter : IAdapter
    {
        public ExcelAdapter(string path)
        {
            try
            {

                using (ExcelPackage pck = new ExcelPackage())
                {
                    using (var stream = File.OpenRead(path))
                    {
                        pck.Load(stream);
                    }

                    ExcelWorksheet ws = pck.Workbook.Worksheets.First();
                    WorksheetToDataTable(ws);
                }
            }
            catch (Exception)
            {
            }
        }
        List<ITask> list_task = new List<ITask>();

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

        public IAccountSettings TestAccount(IAccountSettings accountnForTest)
        {
            throw new NotImplementedException();
        }
    }
}