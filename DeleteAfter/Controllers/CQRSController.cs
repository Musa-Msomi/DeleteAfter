using DeleteAfter.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeleteAfter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CQRSController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CQRSController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUpcomingEvents()
        {
            var query = new GetUpcomingEventsQuery();

            var upcomingEventsToReturn = await _mediator.Send(query);

            return Ok(upcomingEventsToReturn);
        }
    }
}
