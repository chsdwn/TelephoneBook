using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class Person : BaseEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }

        public Person()
        {
            PhoneNumbers = new HashSet<PhoneNumber>();
        }
    }
}