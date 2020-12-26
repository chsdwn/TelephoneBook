using System;
using Domain.Common;

namespace Domain.Entities
{
    public class PhoneNumber : BaseEntity
    {
        public Guid Id { get; set; }
        public Person Person { get; set; }
        public Guid PersonId { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
    }
}