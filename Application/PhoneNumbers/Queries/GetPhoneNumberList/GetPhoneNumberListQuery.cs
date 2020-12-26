using System;
using MediatR;

namespace Application.PhoneNumbers.Queries.GetPhoneNumberList
{
    public class GetPhoneNumberListQuery : IRequest<PhoneNumberVM>
    {
        public Guid PersonId { get; set; }
    }
}