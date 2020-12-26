using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.PhoneNumbers.Commands.DeletePhoneNumber
{
    public class DeletePhoneNumberCommandHandler : IRequestHandler<DeletePhoneNumberCommand>
    {
        private readonly ITelephoneBookDbContext _context;
        private readonly IMapper _mapper;

        public DeletePhoneNumberCommandHandler(ITelephoneBookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePhoneNumberCommand request, CancellationToken cancellationToken)
        {
            foreach (var id in request.Ids)
            {
                var phoneNumber = await _context.PhoneNumbers.FindAsync(id);
                if (phoneNumber is null)
                    throw new Exception("Telefon numarası bulunamadı.");

                _context.PhoneNumbers.Remove(phoneNumber);
            }

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}