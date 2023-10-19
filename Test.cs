using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription_Listing
{
    
    public class Test
    {
        RestHelp _rh = new RestHelp("demo", "demo");

        public List<Subscription> Subscriptions = new List<Subscription>();

        public async Task Go()
        {
            string cursor = null;
            do
            {
                // https://apis.e-conomic.com/subscriptionsapi/v2.0.0/subscriptions
                var datatuple = await _rh.GetOpenApiCollectionAsync<Subscription>(RestApi.subscriptionsapi, "v2.0.0", "subscriptions", null, cursor);
                cursor = datatuple.Item1;
                Subscriptions.AddRange(datatuple.Item2);
            }
            while (cursor != null);
        }
    }
}
