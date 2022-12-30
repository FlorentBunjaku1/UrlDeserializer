namespace DotNetUrlDeserializer.Benchmark
{
    public static class DataGenerator
    {
        public static string[] JsonText =
        {
            "{\"clientId\":3,\"date\":\"2017-01-03\",\"filters\":{\"clientId\":2,\"date\":\"2017-01-01\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}}",
            "{\"clientId\":4,\"date\":\"2017-01-11\",\"filters\":{\"clientId\":2,\"date\":\"2017-01-01\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}}",
            "{\"clientId\":5,\"date\":\"2017-01-01\",\"filters\":{\"clientId\":2,\"date\":\"2017-01-01\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}}",
            "{\"clientId\":6,\"date\":\"2017-01-12\",\"filters\":{\"clientId\":2,\"date\":\"2017-01-01\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}}",
            "{\"clientId\":7,\"date\":\"2017-01-03\",\"filters\":{\"clientId\":2,\"date\":\"2017-01-01\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}}",
            "{\"clientId\":8,\"date\":\"2019-01-01\",\"filters\":{\"clientId\":2,\"date\":\"2017-01-01\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}}",
            "{\"clientId\":9,\"date\":\"2020-01-01\",\"filters\":{\"clientId\":2,\"date\":\"2017-01-01\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}}",
            "{\"clientId\":10,\"date\":\"2022-01-01\",\"filters\":{\"clientId\":2,\"date\":\"2017-01-01\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}}",
            "{\"clientId\":11,\"date\":\"2023-01-01\",\"filters\":{\"clientId\":2,\"date\":\"2017-01-01\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}}",
            "{\"clientId\":12,\"date\":\"2015-01-01\",\"filters\":{\"clientId\":2,\"date\":\"2017-01-01\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}}",
        };
        
        public static string[] UrlEncoded =
        {
            "clientId=2&date=2017-01-01&filters={\"clientId\":2,\"date\":\"2017-01-02\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}",
            "clientId=3&date=2017-01-01&filters={\"clientId\":2,\"date\":\"2017-01-01\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}",
            "clientId=4&date=2017-01-01&filters={\"clientId\":2,\"date\":\"2017-05-01\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}",
            "clientId=5&date=2017-01-01&filters={\"clientId\":2,\"date\":\"2017-01-01\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}",
            "clientId=6&date=2017-01-01&filters={\"clientId\":2,\"date\":\"2017-01-01\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}",
            "clientId=7&date=2017-01-01&filters={\"clientId\":2,\"date\":\"2017-01-11\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}",
            "clientId=8&date=2017-01-01&filters={\"clientId\":2,\"date\":\"2017-01-01\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}",
            "clientId=9&date=2017-01-01&filters={\"clientId\":2,\"date\":\"2013-01-01\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}",
            "clientId=10&date=2017-01-01&filters={\"clientId\":2,\"date\":\"2016-01-01\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}",
            "clientId=11&date=2017-01-01&filters={\"clientId\":2,\"date\":\"2019-01-01\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}",
        };    
    }
}
