using Hepsiburada.CampaignModule.Domain.Product;
using Hepsiburada.CampaignModule.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hepsiburada.CampaignModule.Domain.Campaign
{
    public class CampaignDto : Entity
    {
        public CampaignDto(string name, ProductDto product, int duration, int limit, int targetSalesCount)
        {
            Name = new Name(name);
            Product = product;
            Duration = new Duration(duration);
            Limit = new PriceManipulationLimit(limit);
            Count = new TargetSalesCount(targetSalesCount);
            Status = true;
            Id = new Guid();
        }
        public Name Name { get; private set; }
        public ProductDto Product { get; private set; }
        public Duration Duration { get; private set; }
        public PriceManipulationLimit Limit { get; private set; }
        public TargetSalesCount Count { get; private set; }
        public bool Status { get; private set; }
        public int TotalSalesCount { get; private set; }
        public void IncraseTotalSalesCount(int quantity) => TotalSalesCount += quantity;
        public void CampaignClose() => Status = false;
        public bool HasTargetSalesCountExceed(int quantity) => TotalSalesCount + quantity > Count.Value;
        public bool IsPriceManipulationLimitExceed()
        {
            var maximumManipulationValue = Product.RealPrice.Value * (100 - Limit.Value) / 100;

            return Product.Price.Value < maximumManipulationValue;
        }

        public bool HasDuration(TimeSpan localTime) => localTime.Hours < Duration.Value;

        public string GetStatusString() => Status ? "Active" : "Passive";

    }
}
