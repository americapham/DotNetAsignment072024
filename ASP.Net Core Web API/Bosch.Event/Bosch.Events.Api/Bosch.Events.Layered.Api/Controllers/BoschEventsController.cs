using Bosch.Events.UseCases.DTOs.EventDtos;
using Bosch.Events.UseCases.Features.Events.Commands.CreateEvent;
using Bosch.Events.UseCases.Features.Events.Queries.GetAllEvents;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bosch.Events.Layered.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BoschEventsController : ControllerBase
    {
        
        private readonly IMediator _mediator;

        public BoschEventsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<EventDto>>> Get()
        {
            try
            {
                var events = await _mediator.Send(new GetAllEventsQuery());
                if (events == null || events.Count == 0)
                {
                    return NotFound(new { Message = "Sorry! No Events Found!" });
                }
                return Ok(events);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        /*
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<EventDto>>> GetDetails(int id)
        {
            try
            {
                var event = await _mediator.Send(new GetEventDetailsQuery() { EventId = id });
                if (event == null)
                {
                    return NotFound(new { Message = "Sorry! No Events Found!" });
                }
                return Ok(event);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EventDto>> Post(InsertEventDto event)
        {
            if (ModelState.IsValid)
            {
                int result = await _mediator.Send(new CreateEventCommand() { Event = event });
                if (result > 0)
                {
                    return Created("GetDetails", event);
                }
            }
            return BadRequest(new { Message = "Event Creation Failed! Please retry!" });
        }
        */
    }
}
