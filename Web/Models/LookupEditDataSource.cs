namespace Web.Models
{
    public class LookupEditDataSource
    {
        public string Display { get; set; }
        public string Value { get; set; }

        public LookupEditDataSource()
        {

        }

        public LookupEditDataSource(string _Display, string _Value)
        {
            Display = _Display;
            Value = _Value;
        }
    }
}
