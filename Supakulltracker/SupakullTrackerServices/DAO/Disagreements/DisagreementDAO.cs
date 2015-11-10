namespace SupakullTrackerServices
{
    public class DisagreementDAO
    {
        public virtual int ID { get; set; }
        public virtual string FieldName { get; set; }
        public virtual TaskMainDAO TaskMainDaoLinked { get; set; }
        
        public DisagreementDAO()
        {
        }

        public DisagreementDAO(string FieldName, TaskMainDAO TaskMainDaoLinked)
        {
            this.FieldName = FieldName;
            this.TaskMainDaoLinked = TaskMainDaoLinked;
        }
    }
}