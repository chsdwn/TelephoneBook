using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Persons.Queries.GetPersonDetail
{
    public class GetPersonDetailQueryHandler : IRequestHandler<GetPersonDetailQuery, PersonDetailVM>
    {
        private readonly ITelephoneBookDbContext _context;
        private readonly IMapper _mapper;

        public GetPersonDetailQueryHandler(ITelephoneBookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PersonDetailVM> Handle(
            GetPersonDetailQuery request,
            CancellationToken cancellationToken)
        {
            var person = await _context.Persons.FindAsync(request.Id);
            if (person is null)
                throw new Exception("Kişi bulunamadı");

            return _mapper.Map<PersonDetailVM>(person);
        }
    }
}