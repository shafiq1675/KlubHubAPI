using KlubHub.Data;
using KlubHub.Model;
using Microsoft.EntityFrameworkCore;

namespace KlubHub.Repository
{
    public interface IEventRepository
    {
        void AddEvent(Event member);
        void UpdateEvent(Event member);
        IEnumerable<Event> Get();

        Event Get(int EventId);
    }
    public class EventRepository : IEventRepository
    {
        private readonly KlubHubDbContext _dbContext;

        public EventRepository(KlubHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddEvent(Event eventId)
        {
            try
            {
                eventId.CreatedDate = DateTime.Now;
                eventId.ModifiedDate = DateTime.Now;
                eventId.IsDeleted = false;
                eventId.IsActive = true;
                _ = _dbContext.Event.Add(eventId);
                _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public void UpdateEvent(Event clubEvent)
        {
            Event? tempUser = _dbContext.Event.FirstOrDefault(x => x.EventId == clubEvent.EventId);
            if (tempUser != null)
            {
                tempUser.EventName = clubEvent.EventName;
                tempUser.EventPlace = clubEvent.EventPlace;
                tempUser.EventDescription = clubEvent.EventDescription;
                tempUser.ImageUrl = clubEvent.ImageUrl;
                tempUser.IsActive = clubEvent.IsActive;
                tempUser.IsDeleted = clubEvent.IsDeleted;
                tempUser.ModifiedDate = DateTime.Now;
                _ = _dbContext.Event.Update(tempUser);
                _dbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<Event> Get()
        {
            return _dbContext.Event.ToList();
        }
        public Event Get(int eventId)
        {
            return _dbContext.Event.Where(x=> x.EventId == eventId).FirstOrDefault();
        }
    }
}
