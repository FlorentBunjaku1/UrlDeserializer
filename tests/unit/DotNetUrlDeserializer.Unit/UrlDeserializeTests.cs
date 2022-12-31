using System;
using System.Collections.Generic;
using DotNetUrlDeserializer.Implementation;
using DotNetUrlDeserializer.Unit.Stubs;
using FluentAssertions;
using Xunit;

namespace DotNetUrlDeserializer.Unit
{
    public class UrlDeserializeTests
    {
        [Fact]
        public void Deserialize_WithFullString_ReturnsCorrectResult()
        {
            // Arrange
            var expectedResult = new User
            {
                FirstName = "Test",
                LastName = "Test",
                Age = 30,
                Verified = true,
                Height = 1.90,
                Address = new Address
                {
                    Number = 23,
                    Street = "Street 1",
                    Country = new Country
                    {
                        Code = "US",
                        Name = "United State"
                    },
                },
                Friends = new List<User>
                {
                    new()
                    {
                        FirstName = "Test2",
                        LastName = "Test2",
                        Age = 30,
                        Verified = false,
                        Height = 1.90,
                        Address = new Address
                        {
                            Number = 23,
                            Street = "Street 2",
                            Country = new Country
                            {
                                Code = "US",
                                Name = "United State"
                            },
                        }
                    }
                }
            };

            const string urlEncoded = "firstname=Test&lastname=Test&Age=30&address={\"Country\":{\"Name\":\"United State\",\"Code\":\"US\"},\"City\":null,\"Street\":\"Street 1\",\"Number\":23},\"Verified\":true,\"Friends\":[{\"FirstName\":\"Test2\",\"LastName\":\"Test2\",\"Age\":30,\"Address\":{\"Country\":{\"Name\":\"United State\",\"Code\":\"US\"},\"City\":null,\"Street\":\"Street 2\",\"Number\":23},\"Verified\":false,\"Friends\":null,\"Height\":1.9}]&Height=1.9";

            // Act
            var result = UrlDeserializer.Deserialize<User>(urlEncoded);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
        
        [Fact]
        public void Deserialize_WithUncompletedString_ReturnsCorrectResult()
        {
            // Arrange
            var expectedResult = new User
            {
                Age = 30,
                Verified = true,
                Height = 1.90,
                Address = new Address
                {
                    Number = 23,
                    Street = "Street 1",
                    Country = new Country
                    {
                        Code = "US",
                        Name = "United State"
                    },
                },
                Friends = new List<User>
                {
                    new()
                    {
                        FirstName = "Test2",
                        LastName = "Test2",
                        Age = 30,
                        Verified = false,
                        Height = 1.90,
                        Address = new Address
                        {
                            Number = 23,
                            Street = "Street 2",
                            Country = new Country
                            {
                                Code = "US",
                                Name = "United State"
                            },
                        }
                    }
                }
            };

            const string urlEncoded = "firstname=&Age=30&address={\"Country\":{\"Name\":\"United State\",\"Code\":\"US\"},\"City\":null,\"Street\":\"Street 1\",\"Number\":23},\"Verified\":true,\"Friends\":[{\"FirstName\":\"Test2\",\"LastName\":\"Test2\",\"Age\":30,\"Address\":{\"Country\":{\"Name\":\"United State\",\"Code\":\"US\"},\"City\":null,\"Street\":\"Street 2\",\"Number\":23},\"Verified\":false,\"Friends\":null,\"Height\":1.9}]&Height=1.9&lastname=";

            // Act
            var result = UrlDeserializer.Deserialize<User>(urlEncoded);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
