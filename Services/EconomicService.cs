using System;

namespace Subscription_Listing.Services
{
    public class EconomicService
    {
        private readonly RestHelp _restHelp;
        
        public EconomicService()
        {
            _restHelp = new RestHelp("demo", "demo"); // Should be extracted and parsed from elsewhere
        }
    }
}