using System;
using System.Collections.Generic;
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
            var subscriptions = new List<Subscription>();
            
            string cursor = null;
            do
            {
                // https://apis.e-conomic.com/subscriptionsapi/v2.0.0/subscriptions
                var datatuple = await _restHelp.GetOpenApiCollectionAsync<Subscription>(RestApi.subscriptionsapi, "v2.0.0", "subscriptions", null, cursor);
                cursor = datatuple.Item1;
                subscriptions.AddRange(datatuple.Item2);
            }
            while (cursor != null);

            return subscriptions;
        }

        public async Task<List<Subscriber>> FetchSubscribers()
        {
            var subscribers = new List<Subscriber>();
            
            string cursor = null;
            do
            {
                // https://apis.e-conomic.com/subscriptionsapi/v2.0.0/subscriptions
                var datatuple = await _restHelp.GetOpenApiCollectionAsync<Subscriber>(RestApi.subscriptionsapi, "v2.0.0", "subscribers", null, cursor);
                cursor = datatuple.Item1;
                subscribers.AddRange(datatuple.Item2);
            }
            while (cursor != null);

            return subscribers;
        }
    }
}