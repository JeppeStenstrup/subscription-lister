using System.Collections.Generic;
using System.Threading.Tasks;

namespace Subscription_Listing.Interfaces
{
    public interface IEconomicService
    {
        Task<List<Subscription>> FetchSubscriptions();
        Task<List<Subscriber>> FetchSubscribers();
    }
}