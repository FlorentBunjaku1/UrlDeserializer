namespace DotNetUrlDeserializer.Benchmark
{
    public class FilterStub
    {
        public double clientId { get; set; }
        public DateTime date { get; set; }
        public Filter filters { get; set; }
    }

    public class Filter
    {
        public int clientId { get; set; }
        public DateTime date { get; set; }
        public Date filters { get; set; }
    }

    public class Date
    {
        public string[] months { get; set; }
        public string[] days { get; set; }
    }
}
