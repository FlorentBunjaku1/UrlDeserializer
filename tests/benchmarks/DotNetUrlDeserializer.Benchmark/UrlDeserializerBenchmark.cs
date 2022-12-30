using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using DotNetUrlDeserializer.Implementation;

namespace DotNetUrlDeserializer.Benchmark
{
    [MemoryDiagnoser]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public class UrlDeserializerBenchmark
    {
        [BenchmarkCategory("OneExample"), Benchmark(Baseline = true)]
        public void JsonDeserializer_OneExample()
        {
            JsonSerializer.Deserialize<FilterStub>(
                "{\"clientId\":2,\"date\":\"2017-01-01\",\"filters\":{\"clientId\":2,\"date\":\"2017-01-01\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}}");
        }
    
        [BenchmarkCategory("TenExamples"), Benchmark(Baseline = true)]
        public void JsonDeserializer_TenExamples()
        {
            foreach (var txt in DataGenerator.JsonText)
            {
                JsonSerializer.Deserialize<FilterStub>(txt);
            }
        }
        
        [BenchmarkCategory("OneExample"), Benchmark]
        public void UrlDeserializer_Span_OneExample()
        {
            UrlDeserializer.Deserialize<FilterStub>("clientId=2&date=2017-01-01&filters={\"clientId\":2,\"date\":\"2017-01-01\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}");
        }
    
        [BenchmarkCategory("TenExamples"), Benchmark]
        public void UrlDeserializer_Span_TenExamples()
        {
            foreach (var txt in DataGenerator.UrlEncoded)
            { 
                UrlDeserializer.Deserialize<FilterStub>(txt);
            }
        }
    }
}
