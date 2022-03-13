using Hepsiburada.CampaignModule.Domain.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hepsiburada.CampaignModule.Domain.Order
{
    public interface IOrderService
    {
        void AddOrder(ProductDto product, int quantity, TimeSpan systemTime);

        List<OrderDto> GetOrdersByCampaignName(string campaignName);

        List<OrderDto> GetOrders();
        int GetTotalSalesByCampaign(string value);
        double GetAvarageItemPriceByCampaign(string value);
    }
}
