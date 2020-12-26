using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.PhoneNumbers.Commands.CreatePhoneNumber;
using Application.PhoneNumbers.Commands.DeletePhoneNumber;
using Application.PhoneNumbers.Commands.UpdatePhoneNumber;
using Application.PhoneNumbers.Queries.GetPhoneNumberList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    public class PhoneNumbersController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneNumberVM>> GetAll(Guid id)
        {
            var phoneNumbers = await Mediator.Send(new GetPhoneNumberListQuery { PersonId = id });
            return phoneNumbers;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create(CreatePhoneNumberCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(UpdatePhoneNumberCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid[] ids)
        {
            await Mediator.Send(new DeletePhoneNumberCommand { Ids = ids });
            return NoContent();
        }
    }
}