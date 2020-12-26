using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Persons.Commands.CreatePerson;
using Application.Persons.Commands.DeletePerson;
using Application.Persons.Commands.UpdatePerson;
using Application.Persons.Queries.GetPersonDetail;
using Application.Persons.Queries.GetPersonsList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PersonsController : BaseController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonDetailVM>> Get(Guid id)
        {
            var person = await Mediator.Send(new GetPersonDetailQuery { Id = id });
            return Ok(person);
        }

        [HttpPost]
        [Route("getall")]
        public async Task<ActionResult<PersonListVM>> GetAll(GetPersonsListQuery query)
        {
            var result = await Mediator.Send(query);
            return result;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Route("create")]
        public async Task<IActionResult> Create(CreatePersonCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("update")]
        public async Task<IActionResult> Update(UpdatePersonCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid[] ids)
        {
            await Mediator.Send(new DeletePersonCommand { Ids = ids });
            return NoContent();
        }
    }
}