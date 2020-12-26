using System.Collections.Generic;

namespace Application.PhoneNumbers.Queries.GetPhoneNumberList
{
    public class PhoneNumberVM
    {
        public int Count { get; set; }
        public List<PhoneNumberDto> PhoneNumbers { get; set; }
    }
}