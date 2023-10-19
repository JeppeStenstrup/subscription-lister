using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription_Listing
{
    /// <summary>
    /// DTO Subscription
    /// </summary>
    public class Subscription
    {
        public int number { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int interval { get; set; }
        public bool isCalendarBased { get; set; }
        public int collection { get; set; }
        public bool includeName { get; set; }
        public bool includePeriod { get; set; }
        public bool allowMoreThanOnePerCustomer { get; set; }
        public bool accrue { get; set; }
        public bool isBarred { get; set; }
        public DateTime lastUpdated { get; set; }
        public string objectVersion { get; set; }
    }
}
