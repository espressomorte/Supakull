using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupakullTrackerServices
{
    public static class AdapterInstanceFactory
    {
        public static IAdapter GetCurentAdapterInstance(Sources source)
        {
            switch (source)
            {
                case Sources.DataBase:
                    return new DatabaseAdapter();
                case Sources.Trello:
                    return new TrelloManager();
                case Sources.Excel:
                    return null;
                case Sources.GoogleSheets:
                    return new GoogleSheetsAdapter();
                default:
                    return null;
            }
        }
    }
}
