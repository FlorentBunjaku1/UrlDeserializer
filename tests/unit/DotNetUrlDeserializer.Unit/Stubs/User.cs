using System.Collections.Generic;

namespace DotNetUrlDeserializer.Unit.Stubs
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
        public bool Verified { get; set; }
        public List<User> Friends { get; set; }
        public double Height { get; set; }
    }

    public class Address
    {
        public Country Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
    }

    public class Country
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
