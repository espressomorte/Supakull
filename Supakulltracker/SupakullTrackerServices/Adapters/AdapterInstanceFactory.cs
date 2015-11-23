﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloManagerApp;

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
                    return new TrelloManager("");
                case Sources.Excel:
                    return new ExcelAdapter("");
                case Sources.GoogleSheets:
                    return new GoogleSheetsAdapter();
                default:
                    return null;
            }
        }
    }
}