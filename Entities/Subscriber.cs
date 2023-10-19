using System;

namespace Subscription_Listing
{
    /// <summary>
    /// DTO Subscriber
    /// Extracted from https://apis.e-conomic.com/#Subscriptions..tag/Subscribers
    /// </summary>
    public class Subscriber
    {
        public int number { get; set; }
        public int subscriptionNumber { get; set; }
        public int customerNumber { get; set; }
        public int yourRef { get; set; }
        public string otherRef { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public double specialPrice { get; set; }
        public double discountPercentage { get; set; }
        public DateTime discountExpiryDate { get; set; }
        public int priceFactor { get; set; }
        public DateTime registrationDate { get; set; }
        public DateTime expiryDate { get; set; }
        public int projectNumber { get; set; }
        public int departmentNumber { get; set; }
        public int bookedInvoiceId { get; set; }
        public int draftDocumentId { get; set; }
        public string extraTextForInvoice { get; set; }
        public string comments { get; set; }
        public DateTime lastUpdated { get; set; }
        public string objectVersion { get; set; }
    }
}