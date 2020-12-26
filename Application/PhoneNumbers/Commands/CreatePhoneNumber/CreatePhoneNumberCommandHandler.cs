using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.PhoneNumbers.Commands.CreatePhoneNumber
{
    public class CreatePhoneNumberCommandHandler : IRequestHandler<CreatePhoneNumberCommand>
    {
        private readonly ITelephoneBookDbContext _context;
        private readonly IMapper _mapper;

        public CreatePhoneNumberCommandHandler(ITelephoneBookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreatePhoneNumberCommand request, CancellationToken cancellationToken)
        {
            var phoneNumber = _mapper.Map<PhoneNumber>(request);

            _context.PhoneNumbers.Add(phoneNumber);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}