using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand>
    {
        private readonly ITelephoneBookDbContext _context;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(ITelephoneBookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(
            CreatePersonCommand request,
            CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Person>(request);

            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }

}