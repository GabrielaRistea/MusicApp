using Music_App.Context;
using Music_App.Models;
using Music_App.Repositories.Interfaces;

namespace Music_App.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private MusicAppContext _context;
        public SubscriptionRepository(MusicAppContext musicContext)
        {
            _context = musicContext;
        }
        public IEnumerable<Subscription> GetAll()
        {
            return _context.Subscriptions.ToList();
        }
        public void Create(Subscription subscription)
        {
            _context.Subscriptions.Add(subscription);
        }
        public void Delete(Subscription subscription)
        {
            _context.Subscriptions.Remove(subscription);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public bool SubscriptionExists(int id)
        {
            return _context.Subscriptions.Any(s => s.Id == id);
        }

        public void Update(Subscription subscription)
        {
            _context.Subscriptions.Update(subscription);
        }
        public Subscription GetById(int id)
        {
            return _context.Subscriptions.FirstOrDefault(s => s.Id == id);
        }
    }
}
