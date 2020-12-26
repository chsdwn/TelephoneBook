using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Persons.Queries.GetPersonsList
{
    public class GetPersonsListQueryHandler : IRequestHandler<GetPersonsListQuery, PersonListVM>
    {
        private readonly ITelephoneBookDbContext _context;
        private readonly IMapper _mapper;

        public GetPersonsListQueryHandler(ITelephoneBookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PersonListVM> Handle(
            GetPersonsListQuery request,
            CancellationToken cancellationToken)
        {
            var personList = new List<Person>();
            var skip = (request.Page - 1) * request.PageSize;

            if (!string.IsNullOrEmpty(request.FirstName))
                personList = await _context.Persons
                    .Where(p => p.FirstName.ToLower().Contains(request.FirstName.ToLower()))
                    .ToListAsync();
            else if (!string.IsNullOrEmpty(request.LastName))
                personList = await _context.Persons
                    .Where(p => p.LastName.ToLower().Contains(request.LastName.ToLower()))
                    .ToListAsync();
            else if (!string.IsNullOrEmpty(request.City))
                personList = await _context.Persons
                    .Where(p => p.City.ToLower().Contains(request.City.ToLower()))
                    .ToListAsync();
            else if (!string.IsNullOrEmpty(request.PhoneNumber))
                personList = await _context.Persons
                    .Where(p => p.PhoneNumbers.Any(pn => pn.Number.Contains(request.PhoneNumber)))
                    .ToListAsync();
            else
                personList = await _context.Persons
                    .ToListAsync();

            var personsCount = personList.Count();
            var persons = _mapper.Map<List<PersonListDto>>(personList.OrderBy(p => p.CreatedAt)
                                                                     .Skip(skip)
                                                                     .Take(request.PageSize));

            return new PersonListVM
            {
                Count = personsCount,
                Persons = persons
            };
        }
    }
}