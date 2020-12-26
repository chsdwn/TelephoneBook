using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Persons.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly ITelephoneBookDbContext _context;
        private readonly IMapper _mapper;

        public UpdatePersonCommandHandler(ITelephoneBookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _context.Persons.FindAsync(request.Id);
            if (person is null)
                throw new Exception("Kişi bulunamadı");

            person.FirstName = CheckIsChanged(person.FirstName, request.FirstName);
            person.LastName = CheckIsChanged(person.LastName, request.LastName);
            person.Country = CheckIsChanged(person.Country, request.Country);
            person.City = CheckIsChanged(person.City, request.City);
            person.District = CheckIsChanged(person.District, request.District);
            person.Street = CheckIsChanged(person.Street, request.Street);
            person.ZipCode = CheckIsChanged(person.ZipCode, request.ZipCode);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }

        private string CheckIsChanged(string current, string changed)
        {
            if (current.Equals(changed))
                return current;

            if (string.IsNullOrEmpty(changed) || string.IsNullOrWhiteSpace(changed))
                return current;

            return changed;
        }
    }
}