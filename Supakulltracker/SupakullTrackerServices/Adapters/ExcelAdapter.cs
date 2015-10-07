using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ExcelObj = Microsoft.Office.Interop.Excel;

namespace SupakullTrackerServices
{
    public class ExcelAdapter : IAdapter
    {
        string path = String.Empty;
        List<ITask> list_task = new List<ITask>();

        public ExcelAdapter(string path)
        {
            this.path = path;
        }

        private void Work_Excel()
        {
            ExcelObj.Application app = new ExcelObj.Application();
            ExcelObj.Workbook workbook;
            ExcelObj.Worksheet NwSheet;
            ExcelObj.Range ShtRange;
            DataTable dt = new DataTable();
            
            workbook = app.Workbooks.Open(path, Missing.Value,
            Missing.Value, Missing.Value, Missing.Value, Missing.Value,
            Missing.Value, Missing.Value, Missing.Value, Missing.Value,
            Missing.Value, Missing.Value, Missing.Value, Missing.Value,
            Missing.Value);

            //Устанавливаем номер листа из котрого будут извлекаться данные
            //Листы нумеруются от 1
            NwSheet = (ExcelObj.Worksheet)workbook.Sheets.get_Item(1);
            ShtRange = NwSheet.UsedRange;
            // добавляем кол-во столбцов - 7 штук
            for (int Cnum = 1; Cnum <= ShtRange.Columns.Count; Cnum++)
            {
                dt.Columns.Add(
                   new DataColumn((ShtRange.Cells[1, Cnum] as ExcelObj.Range).Value2.ToString()));
            }
            dt.AcceptChanges();

            // массив заголовков таблицы
            string[] columnNames = new String[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                columnNames[i] = dt.Columns[i].ColumnName;
            }

            for (int Rnum = 2; Rnum <= ShtRange.Rows.Count; Rnum++)
            {
                DataRow dr = dt.NewRow();
                for (int Cnum = 1; Cnum <= ShtRange.Columns.Count; Cnum++)
                {
                    if ((ShtRange.Cells[Rnum, Cnum] as ExcelObj.Range).Value2 != null)
                    {
                        dr[Cnum - 1] = (ShtRange.Cells[Rnum, Cnum] as ExcelObj.Range).Value2.ToString();
                    }
                }
                write_in_table(dr, columnNames);

                dt.AcceptChanges();
            }

            app.Quit();
        }
        
        private void write_in_table(DataRow dr, string[] columnNames)
        {
            object[] array = new object[10];

            TaskMain task = new TaskMain();
            array = dr.ItemArray;

            task.TaskID = array[0].ToString();
            task.Summary = array[1].ToString();
            task.SubtaskType = array[2].ToString();
            task.Status = array[3].ToString();
            task.Priority = array[4].ToString();
            task.CreatedDate = array[5].ToString();
            task.CreatedBy = array[6].ToString();

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
    }
}