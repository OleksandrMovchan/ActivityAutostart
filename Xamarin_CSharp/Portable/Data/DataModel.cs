namespace Portable.Data
{
    public class DataModel
    {
        public string Id { get; set; }
        public bool IsChecked { get; set; }

        public DataModel(string id, bool isChecked)
        {
            Id = id;
            IsChecked = isChecked;
        }
    }
}