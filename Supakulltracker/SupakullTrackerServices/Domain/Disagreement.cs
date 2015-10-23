using System;

namespace SupakullTrackerServices
{
    public class Disagreement: IEquatable<Disagreement>
    {
        public string FieldCode { get; set; }

        public Disagreement(string fieldCode)
        {
            this.FieldCode = fieldCode;
        }

        public bool Equals(Disagreement disagreementToCompare)
        {
            if (disagreementToCompare == null)
            {
                return false;
            }
            return (this.FieldCode.Equals(disagreementToCompare.FieldCode));
        }
    }
}