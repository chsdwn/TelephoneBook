using System;
using MediatR;

namespace Application.PhoneNumbers.Commands.CreatePhoneNumber
{
    public class CreatePhoneNumberCommand : IRequest
    {
        public Guid PersonId { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
    }
}