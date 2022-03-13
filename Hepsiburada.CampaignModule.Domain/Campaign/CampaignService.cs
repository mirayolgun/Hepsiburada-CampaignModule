using Hepsiburada.CampaignModule.Domain.Order;
using Hepsiburada.CampaignModule.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hepsiburada.CampaignModule.Domain.Campaign
{
    public class CampaignService : ICampaignService
    {
        private List<CampaignDto> CampaignList { get; set; }

        private readonly IOrderService orderService;
        public CampaignService(IOrderService orderService)
        {
            if (CampaignList == null)
                CampaignList = new List<CampaignDto>();
            this.orderService = orderService;
        }

        public void AddCampaing(string campaignName, ProductDto product, int duration, int priceManipulationLimit, int targetSalesCount)
        {
            if (GetCampaignByName(campaignName) == null)
            {
                if (!product.HasCampaign() && product.Stock.HasStock(targetSalesCount))
                {

                    var campaign = new CampaignDto(campaignName, product, duration, priceManipulationLimit, targetSalesCount);

                    product.SetCampaign(campaign);

                    CampaignList.Add(campaign);

                    Logger.Log($"Campaign created; name {campaign.Name.Value}, product {product.ProductCode.Value}, duration {campaign.Duration.Value}, limit {campaign.Limit.Value}, target sales count {campaign.Count.Value}");
                }
            }
            else
            {
                throw new LogicException("Campaign name already exists");
            }
        }

        public CampaignDto GetCampaignInfo(string name)
        {
            var campaign = GetCampaignByName(name);

            if (campaign != null)
            {
                int totalSales = orderService.GetTotalSalesByCampaign(campaign.Name.Value);
                double avarageItemPrice = orderService.GetAvarageItemPriceByCampaign(campaign.Name.Value);

                Logger.Log($"Campaign {campaign.Name.Value} info; Status {campaign.GetStatusString()}, Target Sales {campaign.Count.Value}, Total Sales {totalSales}, Turnover {totalSales * avarageItemPrice}, Average Item Price {avarageItemPrice}");
                return campaign;
            }
            else
            {
                Logger.Log("Campaign name is not found");

                return null;
            }
        }

        private CampaignDto GetCampaign(Func<CampaignDto, bool> predicate) => CampaignList.FirstOrDefault(predicate);

        public CampaignDto GetCampaignByProductCode(string productCode) => GetCampaign(x => x.Product.ProductCode.Value == productCode);

        public CampaignDto GetCampaignByName(string name) => GetCampaign(x => x.Name.Value == name);

    }
}
