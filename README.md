## Overview

This is a simple library that allows deserialization of UrlEncoded formatted strings. Use cases for it can be `x-www-form-urlencoded` or `QueryString`.

###

### Usage


#### When you have a string which is already decoded.
```csharp
using DotNetUrlDeserializer.Implementation;

var urlEncoded = "dob=2001-01-01&userId=123&alive=true&height=1.83&pets=[{\"name\":\"Oscar\",\"color\":\"white\",\"type\":2},{\"name\":\"Bailey\",\"color\":\"black\",\"type\":1}]&age=20&username=test";
var user = UrlDeserializer.Deserialize<User>(urlEncoded);

public class User{
    public int userId { get; set; }
    public string username { get; set; }
    public int age { get; set; }
    public double height { get; set; }
    public bool alive { get; set; }
    public Pet[] pets { get; set; }
    public DateTime dob { get; set; }
}

public struct Pet
{
    public string name { get; set; }
    public string color { get; set; }
    public PetType type { get; set; }
}

public enum PetType
{
    Dog = 1,
    Cat = 2
}
```

#### When you have a string which is not yet decoded.
```csharp
using DotNetUrlDeserializer.Implementation;

var urlEncoded = "dob%3D2001-01-01%26userId%3D123%26alive%3Dtrue%26height%3D1.83%26pets%3D%5B%7B%22name%22%3A%22Oscar%22%2C%22color%22%3A%22white%22%2C%22type%22%3A2%7D%2C%7B%22name%22%3A%22Bailey%22%2C%22color%22%3A%22black%22%2C%22type%22%3A1%7D%5D%26age%3D20%26username%3Dtest";
var user = UrlDeserializer.DeserializeEncoded<User>(urlEncoded);

public class User{
    public int userId { get; set; }
    public string username { get; set; }
    public int age { get; set; }
    public double height { get; set; }
    public bool alive { get; set; }
    public Pet[] pets { get; set; }
    public DateTime dob { get; set; }
}

public struct Pet
{
    public string name { get; set; }
    public string color { get; set; }
    public PetType type { get; set; }
}

public enum PetType
{
    Dog = 1,
    Cat = 2
}
```

### Performance

It has almost the same performance as JsonDeserialization with `System.Text.Json`.

|                           Method |      Mean | Ratio | Allocated | Alloc Ratio |
|--------------------------------- |----------:|------:|----------:|------------:|
|      JsonDeserializer_OneExample |  2.449 us |  1.00 |     984 B |        1.00 |
|  UrlDeserializer_Span_OneExample |  2.958 us |  1.21 |     984 B |        1.00 |
|                                  |           |       |           |             |
|     JsonDeserializer_TenExamples | 23.685 us |  1.00 |    9840 B |        1.00 |
| UrlDeserializer_Span_TenExamples | 29.425 us |  1.24 |    9840 B |        1.00 |

###
Json string used to test JsonDeserializer.
```csharp
"{\"clientId\":3,\"date\":\"2017-01-03\",\"filters\":{\"clientId\":2,\"date\":\"2017-01-01\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}}"
```

UrlEncoded string used to test UrlDeserializer.
```csharp
"clientId=2&date=2017-01-01&filters={\"clientId\":2,\"date\":\"2017-01-02\",\"filters\":{\"days\":[\"monday\",\"tuesday\",\"wednesday\"],\"months\":[\"january\",\"february\"]}}"
```

### Limitations
1. Doesn't support string which contains '=' or '&' as part of the value (e.g username==name&====)

### TODO
1. Make decoding more memory efficient, because the built one doesn't support spans.
