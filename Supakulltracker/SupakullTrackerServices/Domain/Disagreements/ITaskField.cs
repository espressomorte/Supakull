namespace SupakullTrackerServices
{ 
    public interface ITaskField
    {
        string FieldName { get; }
        bool Equals(ITaskField obj);
    }
}
