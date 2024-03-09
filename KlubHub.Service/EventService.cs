using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlubHub.Model;
using KlubHub.Repository;

namespace KlubHub.Service
{
    public interface IEventService
    {
        void AddEvent(Event clubEvent);
        void UpdateEvent(Event clubEvent);
        IEnumerable<Event> Get();
        Event Get(int EventId);
    }
    public class EventService : IEventService
    {
        private readonly IEventRepository _userRepository;

        public EventService(IEventRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void AddEvent(Event clubEvent)
        {
            clubEvent.CreatedDate = DateTime.Now;
            clubEvent.ModifiedDate = DateTime.Now;
            clubEvent.IsDeleted = false;
            clubEvent.CreatedBy = 0;
            _userRepository.AddEvent(clubEvent);
        }

        public void UpdateEvent(Event clubEvent)
        {
            try
            {
                _userRepository.UpdateEvent(clubEvent);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Event> Get()
        {
            return _userRepository.Get();
        }
        public Event Get(int eventId)
        {
            return _userRepository.Get(eventId);
        }
    }
}
