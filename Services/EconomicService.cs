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
            // https://apis.e-conomic.com/subscriptionsapi/v2.0.0/subscriptions
            return await FetchAll<Subscription>(RestApi.subscriptionsapi, "subscriptions");
        }

        public async Task<List<Subscriber>> FetchSubscribers()
        {
            // https://apis.e-conomic.com/subscriptionsapi/v2.0.0/subscribers
            return await FetchAll<Subscriber>(RestApi.subscriptionsapi, "subscribers");
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