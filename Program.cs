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

            Console.WriteLine("Select action:");
            Console.WriteLine("[L]ist all subscriptions");
            Console.WriteLine("[G]et all subscribers");
            var input = Console.ReadLine() ?? "";

            switch (input.ToLower())
            {
                case "l":
                    var subscriptions = await api.FetchSubscriptions();
                    foreach (var subscription in subscriptions.OrderBy(s => s.name))
                    {
                        Console.WriteLine(subscription.name);
                        if (!subscription.SubscriptionLines.Any()) continue;
                        
                        foreach (var subscriptionLine in subscription.SubscriptionLines)
                        {
                            Console.WriteLine($"-- {subscriptionLine.description}");
                        }
                    }
                    break;
                case "g":
                    var subscribers = await api.FetchSubscribers();
                    foreach (var subscriber in subscribers.OrderBy(s => s.startDate))
                    {
                        Console.WriteLine(subscriber.number + $" ({subscriber.startDate})");
                        if (subscriber.subscription == null) continue;
                        
                        Console.WriteLine($"-- {subscriber.subscription.name}");
                    }
                    break;
                default:
                    //TODO: Implement infinite loop with exit clause
                    return;
            }
        }
    }
}
