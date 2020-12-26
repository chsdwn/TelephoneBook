using System;
using MediatR;

namespace Application.PhoneNumbers.Commands.UpdatePhoneNumber
{
    public class UpdatePhoneNumberCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
    }
}