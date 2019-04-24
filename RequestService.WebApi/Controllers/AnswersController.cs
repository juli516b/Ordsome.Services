﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestService.WebApi.Application.Commands.Requests.AnswerCreation;
using System.Threading.Tasks;

namespace RequestService.WebApi.Controllers
{
    public class AnswersController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateAnswerCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
