using System;
using System.Collections.Generic;
using MediatR;

namespace Application.PhoneNumbers.Commands.DeletePhoneNumber
{
    public class DeletePhoneNumberCommand : IRequest
    {
        public Guid[] Ids { get; set; }
    }
}