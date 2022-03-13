using Hepsiburada.CampaignModule.Domain.Campaign;
using Hepsiburada.CampaignModule.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hepsiburada.CampaignModule.Domain.Product
{
    public class ProductDto : Entity
    {
        public ProductDto(string productCode, double price, int stock)
        {
            ProductCode = new ProductCode(productCode);
            RealPrice = new Price(price);
            SetPrice(price);
            Stock = new Stock(stock);
            Id = new Guid();
        }
        public ProductCode ProductCode { get; private set; }
        public Price RealPrice { get; private set; }
        public Price Price { get; private set; }
        public Stock Stock { get; private set; }
        private CampaignDto Campaign { get; set; }
        public void SetCampaign(CampaignDto campaign) => Campaign = campaign;

        private void SetPrice(double price) => Price = new Price(price);
        public void MakeDiscount(double price)
        {
            if (HasCampaign())
            {
                Price.SetPrice(Price.Value + price);
                if (Campaign.IsPriceManipulationLimitExceed())
                {
                    Price.SetPrice(RealPrice.Value);
                    Campaign.CampaignClose();
                }
            }

        }

        internal bool HasCampaign() => Campaign != null && Campaign.Status;

        internal CampaignDto GetCampaign() => Campaign;

    }
}
