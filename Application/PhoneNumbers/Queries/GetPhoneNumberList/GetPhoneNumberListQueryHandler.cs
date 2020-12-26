using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.PhoneNumbers.Queries.GetPhoneNumberList
{
    public class GetPhoneNumberListQueryHandler : IRequestHandler<GetPhoneNumberListQuery, PhoneNumberVM>
    {
        private readonly ITelephoneBookDbContext _context;
        private readonly IMapper _mapper;

        public GetPhoneNumberListQueryHandler(ITelephoneBookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<PhoneNumberVM> Handle(GetPhoneNumberListQuery request, CancellationToken cancellationToken)
        {
            var phoneNumbersList = _context.PhoneNumbers.Where(pn => pn.PersonId == request.PersonId);
            if (phoneNumbersList is null)
                throw new Exception("Telefon numarası bulunamadı");

            var phoneNumbers = _mapper.Map<List<PhoneNumberDto>>(phoneNumbersList);

            return Task.FromResult(new PhoneNumberVM
            {
                Count = phoneNumbers.Count(),
                PhoneNumbers = phoneNumbers
            });
        }
    }
}