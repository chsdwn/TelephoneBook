using System.Collections.Generic;

namespace Application.Persons.Queries.GetPersonsList
{
    public class PersonListVM
    {
        public int Count { get; set; }
        public List<PersonListDto> Persons { get; set; }
    }
}