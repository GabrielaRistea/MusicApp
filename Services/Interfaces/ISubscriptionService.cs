using Music_App.Models;

namespace Music_App.Services.Interfaces
{
    public interface ISubscriptionService
    {
        List<Subscription> GetAllSubscriptions();
        void AddSubscription(Subscription subscription);
        void UpdateSubscription(Subscription subscription);
        void DeleteSubscription(int id);
        bool SubscriptionExists(int id);
        Subscription GetSubscriptionById(int id);
    }
}
