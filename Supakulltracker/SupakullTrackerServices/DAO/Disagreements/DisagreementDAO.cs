namespace SupakullTrackerServices
{
    public class DisagreementDAO
    {
        public virtual string FieldName { get; set; }
        public virtual TaskMainDAO TaskMainDaoLinked { get; set; }
    }
}