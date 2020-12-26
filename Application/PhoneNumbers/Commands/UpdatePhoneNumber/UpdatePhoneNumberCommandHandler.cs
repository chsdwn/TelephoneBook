using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.PhoneNumbers.Commands.UpdatePhoneNumber
{
    public class UpdatePhoneNumberCommandHandler : IRequestHandler<UpdatePhoneNumberCommand>
    {
        private readonly ITelephoneBookDbContext _context;
        private readonly IMapper _mapper;

        public UpdatePhoneNumberCommandHandler(ITelephoneBookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePhoneNumberCommand request, CancellationToken cancellationToken)
        {
            var phoneNumber = await _context.PhoneNumbers.FindAsync(request.Id);
            if (phoneNumber is null)
                throw new Exception("Telefon numarası bulunamadı.");

            phoneNumber.Number = string.IsNullOrEmpty(request.Number) ? phoneNumber.Number : request.Number;
            phoneNumber.Type = string.IsNullOrEmpty(request.Type) ? phoneNumber.Type : request.Type;

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}