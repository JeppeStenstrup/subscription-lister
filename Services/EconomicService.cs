using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Subscription_Listing.Interfaces;

namespace Subscription_Listing.Services
{
    public class EconomicService : IEconomicService
    {
        private readonly RestHelp _restHelp;
        private readonly string apiVersion = "v2.0.0";
        
        public EconomicService()
        {
            _restHelp = new RestHelp("demo", "demo"); // Should be extracted and parsed from elsewhere
        }

        /// <summary>
        /// Fetch request for retreiving all subscriptions, including subscriptionlines
        /// </summary>
        /// <returns>List of Subscriptions -o- null</returns>
        public async Task<List<Subscription>> FetchSubscriptions()
        {
            var subscriptions = await FetchAll<Subscription>(RestApi.subscriptionsapi, "subscriptions");
            
            // Tricky format returned from {api}/subscriptions/{id}/lines (i.e. {[ .. ]}, as opposed to [{items: .. }] from subscriptionlines)
            var lines = await FetchAll<SubscriptionLine>(RestApi.subscriptionsapi, "subscriptionlines");

            foreach (var subscription in subscriptions)
            {
                subscription.SubscriptionLines = lines.Where(l => l.subscriptionNumber == subscription.number).ToList();
            }
            
            return subscriptions;
        }

        /// <summary>
        /// Fetch request for retreiving all subscribers, including subscription
        /// </summary>
        /// <returns>List of Subscribers -o- null</returns>
        public async Task<List<Subscriber>> FetchSubscribers()
        {
            var subscribers = await FetchAll<Subscriber>(RestApi.subscriptionsapi, "subscribers");

            foreach (var subscriber in subscribers)
            {
                subscriber.subscription = await FetchSingle<Subscription>(RestApi.subscriptionsapi,
                    $"subscriptions/{subscriber.subscriptionNumber}");
            }

            return subscribers;
        }

        private async Task<List<T>> FetchAll<T>(RestApi api, string resource)
        {
            var data = new List<T>();
            
            string cursor = null;
            do
            {
                var datatuple = await _restHelp.GetOpenApiCollectionAsync<T>(api, apiVersion, resource, null, cursor);
                cursor = datatuple.Item1;
                data.AddRange(datatuple.Item2);
            }
            while (cursor != null);

            return data;
        }

        private async Task<T> FetchSingle<T>(RestApi api, string resource)
        {
            return await _restHelp.GetOpenApiSingleItemAsync<T>(api, apiVersion, resource);
        }
    }
}