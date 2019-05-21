using System;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : Controller
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext
                                            .RequestServices
                                            .GetService<IMediator>());

        protected Guid GetUserId()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Guid.Parse(userid);
        }
    }
}