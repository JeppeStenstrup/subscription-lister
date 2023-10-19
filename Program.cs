using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription_Listing.Services;

namespace Subscription_Listing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var api = new EconomicService();

            var subscriptions = await api.FetchSubscriptions();

            foreach (var subscription in subscriptions)
            {
                Console.WriteLine(subscription.name);
            }
            
            Console.WriteLine("finished");
            Console.ReadKey();
        }
    }
}
