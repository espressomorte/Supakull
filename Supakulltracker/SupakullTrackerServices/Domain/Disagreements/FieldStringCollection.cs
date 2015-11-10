using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class FieldStringCollection : ITaskField
    {
        public string FieldName { get; }
        private IEnumerable<string> collection;

        public FieldStringCollection(string fieldName, IEnumerable<string> collection)
        {
            this.FieldName = fieldName;
            this.collection = collection;
        }

        public bool Equals(ITaskField fieldToCompare)
        {
            if (fieldToCompare == null)
            {
                return false;
            }
            FieldStringCollection fieldStringCollectionToCompare = fieldToCompare as FieldStringCollection;
            if (fieldStringCollectionToCompare == null)
            {
                return false;
            }

            IEnumerable<string> collectionA = this.collection;
            IEnumerable<string> collectionB = fieldStringCollectionToCompare.collection;
            if(collectionA == null || collectionB == null)
            {
                return true;
            }

            HashSet<string> hashSetA = new HashSet<string>(collectionA);
            HashSet<string> hashSetB = new HashSet<string>(collectionB);

            foreach(string valueA in hashSetA)
            {
                if(!hashSetB.Contains(valueA))
                {
                    return false;
                }
            }
            foreach (string valueB in hashSetB)
            {
                if (!hashSetA.Contains(valueB))
                {
                    return false;
                }
            }

            return true;
        }
    }
}