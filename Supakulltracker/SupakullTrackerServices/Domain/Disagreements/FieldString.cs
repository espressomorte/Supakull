using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class FieldString : ITaskField
    {
        public string FieldName { get; }
        private string value;

        public FieldString(string fieldName, string value)
        {
            this.FieldName = fieldName;
            this.value = value;
        }

        public bool Equals(ITaskField fieldToCompare)
        {
            if (fieldToCompare == null)
            {
                return false;
            }
            FieldString fieldStringToCompare = fieldToCompare as FieldString;
            if (fieldStringToCompare == null)
            {
                return false;
            }

            string valueA = this.value;
            string valueB = fieldStringToCompare.value;
            if(valueA == null || valueB == null)
            {
                return true;
            }

            valueA = valueA.Trim();
            valueB = valueB.Trim();
            return (valueA.Equals(valueB));
        }
    }
}