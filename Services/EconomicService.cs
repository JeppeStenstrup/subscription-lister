using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Subscription_Listing.Services
{
    public class EconomicService
    {
        private readonly RestHelp _restHelp;
        
        public EconomicService()
        {
            _restHelp = new RestHelp("demo", "demo"); // Should be extracted and parsed from elsewhere
        }

        public async Task<List<Subscription>> FetchSubscriptions()
        {
            // https://apis.e-conomic.com/subscriptionsapi/v2.0.0/subscriptions
            var subscriptions = await FetchAll<Subscription>(RestApi.subscriptionsapi, "subscriptions");
            
            // Tricky format returned from {api}/subscriptions/{id}/lines (i.e. {[ .. ]}, as opposed to [{items: .. }] from subscriptionlines)
            var lines = await FetchAll<SubscriptionLine>(RestApi.subscriptionsapi, "subscriptionlines");

            foreach (var subscription in subscriptions)
            {
                subscription.SubscriptionLines = lines.Where(l => l.subscriptionNumber == subscription.number).ToList();
            }
            
            return subscriptions;
        }

        public async Task<List<Subscriber>> FetchSubscribers()
        {
            // https://apis.e-conomic.com/subscriptionsapi/v2.0.0/subscribers
            var subscribers = await FetchAll<Subscriber>(RestApi.subscriptionsapi, "subscribers");

            foreach (var subscriber in subscribers)
            {
                subscriber.subscription =
                    await _restHelp.GetOpenApiSingleItemAsync<Subscription>(RestApi.subscriptionsapi, "v2.0.0", $"subscriptions/{subscriber.subscriptionNumber}");
            }

            return subscribers;
        }

        private async Task<List<T>> FetchAll<T>(RestApi api, string resource)
        {
            var data = new List<T>();
            
            string cursor = null;
            do
            {
                var datatuple = await _restHelp.GetOpenApiCollectionAsync<T>(api, "v2.0.0", resource, null, cursor);
                cursor = datatuple.Item1;
                data.AddRange(datatuple.Item2);
            }
            while (cursor != null);

            return data;
        }
    }
}