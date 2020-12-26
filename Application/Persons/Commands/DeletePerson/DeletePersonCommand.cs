using System;
using System.Collections.Generic;
using MediatR;

namespace Application.Persons.Commands.DeletePerson
{
    public class DeletePersonCommand : IRequest
    {
        public Guid[] Ids { get; set; }
    }
}