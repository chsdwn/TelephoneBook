using System;

namespace Application.PhoneNumbers.Queries.GetPhoneNumberList
{
    public class PhoneNumberDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
    }
}