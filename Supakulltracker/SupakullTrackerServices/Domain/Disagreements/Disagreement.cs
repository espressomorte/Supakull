using System;

namespace SupakullTrackerServices
{
    public class Disagreement: IEquatable<Disagreement>
    {
        public string FieldName { get; set; }

        public Disagreement(string FieldName)
        {
            this.FieldName = FieldName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Disagreement disagreementToCompare = obj as Disagreement;
            if (disagreementToCompare == null)
            {
                return false;
            }
            else
            {
                return Equals(disagreementToCompare);
            }
        }

        public bool Equals(Disagreement disagreementToCompare)
        {
            if (disagreementToCompare == null)
            {
                return false;
            }
            return (this.FieldName.Equals(disagreementToCompare.FieldName));
        }

        public override int GetHashCode()
        {
            return this.FieldName.GetHashCode();
        }
    }
}