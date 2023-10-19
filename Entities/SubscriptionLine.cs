namespace Subscription_Listing
{
    /// <summary>
    /// DTO SubscriptionLine
    /// Extracted from https://apis.e-conomic.com/#Subscriptions..tag/SubscriptionLines
    /// </summary>
    public class SubscriptionLine
    {
        public int number { get; set; }
        public int subscriptionNumber { get; set; }
        public int productNumber { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public double specialPrice { get; set; }
        public int departmentNumber { get; set; }
        public string objectVersion { get; set; }
    }
}