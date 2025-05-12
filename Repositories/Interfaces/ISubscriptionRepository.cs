using Music_App.Models;

namespace Music_App.Repositories.Interfaces
{
    public interface ISubscriptionRepository
    {
        IEnumerable<Subscription> GetAll();
        bool SubscriptionExists(int id);
        void Create(Subscription subscription);
        void Update(Subscription subscription);
        void Delete(Subscription subscription);
        void Save();
        Subscription GetById(int id);
    }
}
