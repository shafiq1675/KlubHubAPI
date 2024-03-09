using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KlubHub.Model;
using KlubHub.Service;

namespace KlubHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _eventService.Get().ToArray();
        }

        [HttpGet("getById/{eventId}")]

        public Event Get(int eventId)
        {
            return _eventService.Get(eventId);
        }

        [HttpPost]
        public IActionResult Post(Event clubEvent)
        {
            try
            {
                this._eventService.AddEvent(clubEvent);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPut]
        public IActionResult UpdateEvent(Event clubEvent)
        {
            this._eventService.UpdateEvent(clubEvent);
            return Ok();
        }

        [HttpDelete("{eventId}")]
        public IActionResult Delete(string eventId)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
