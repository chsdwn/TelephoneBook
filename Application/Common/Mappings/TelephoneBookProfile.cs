using System.Collections.Generic;
using Application.Persons.Commands.CreatePerson;
using Application.Persons.Commands.UpdatePerson;
using Application.Persons.Queries.GetPersonDetail;
using Application.Persons.Queries.GetPersonsList;
using Application.PhoneNumbers.Commands.CreatePhoneNumber;
using Application.PhoneNumbers.Queries.GetPhoneNumberList;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class TelephoneBookProfile : Profile
    {
        public TelephoneBookProfile()
        {
            MapPerson();
            MapPhoneNumber();
        }

        private void MapPerson()
        {
            CreateMap<Person, PersonDetailVM>();
            CreateMap<Person, PersonListDto>();

            CreateMap<CreatePersonCommand, Person>();
        }

        private void MapPhoneNumber()
        {
            CreateMap<PhoneNumber, PhoneNumberDto>();

            CreateMap<CreatePhoneNumberCommand, PhoneNumber>();
        }
    }
}