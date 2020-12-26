using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Persons.Commands.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly ITelephoneBookDbContext _context;

        public DeletePersonCommandHandler(ITelephoneBookDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            foreach (var id in request.Ids)
            {
                var person = await _context.Persons.FindAsync(id);
                if (person is null)
                    throw new Exception("Kişi bulunamadı");

                var hasPhoneNumbers = _context.PhoneNumbers.Any(pn => pn.PersonId == person.Id);
                if (hasPhoneNumbers)
                    throw new Exception($"{person.FirstName} {person.LastName} kişisine " +
                        "kayıtlı telefon numaraları var");

                _context.Persons.Remove(person);
            }

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}