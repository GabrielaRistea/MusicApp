using Music_App.Models;
using Music_App.Repositories.Interfaces;
using Music_App.Services.Interfaces;

namespace Music_App.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private ISubscriptionRepository _subscriptionRepository;
        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public List<Subscription> GetAllSubscriptions()
        {
            return _subscriptionRepository.GetAll().ToList();
        }
        public void AddSubscription(Subscription subscription)
        {
            _subscriptionRepository.Create(subscription);
            _subscriptionRepository.Save();
        }
        public void UpdateSubscription(Subscription subscription)
        {
            _subscriptionRepository.Update(subscription);
            _subscriptionRepository.Save();
        }
        public void DeleteSubscription(int id)
        {
            var subscription = _subscriptionRepository.GetById(id);
            if (subscription != null)
            {
                _subscriptionRepository.Delete(subscription);
                _subscriptionRepository.Save();
            }
        }
        public bool SubscriptionExists(int id)
        {
            return _subscriptionRepository.SubscriptionExists(id);
        }
        public Subscription GetSubscriptionById(int id)
        {
            return _subscriptionRepository.GetById(id);
        }
    }
}
