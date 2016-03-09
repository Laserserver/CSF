using System.Runtime.Serialization;
namespace JsonParse
{
    [DataContract]
    public class Person
    {
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "address")]
        public Address PersonAddress { get; set; }

        [DataMember(Name = "phoneNumbers")]
        public string[] PersonPhones { get; set; }



    }
    [DataContract]
    public class Address
    {
        [DataMember(Name = "streetAddress")]
        public string StreetAddress { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "postalCode")]
        public int Postal { get; set; }
    }
}

