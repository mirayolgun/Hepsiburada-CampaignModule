using Hepsiburada.CampaignModule.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hepsiburada.CampaignModule.Domain.Order
{
    public class OrderService : IOrderService
    {
        private List<OrderDto> OrderList { get; set; }

        public OrderService()
        {
            if (OrderList == null)
                OrderList = new List<OrderDto>();
        }
        public void AddOrder(ProductDto product, int quantity, TimeSpan systemTime)
        {
            if (product.Stock.HasStock(quantity))
            {
                product.Stock.DecraseStock(quantity);

                var order = new OrderDto(product, quantity);

                if (product.HasCampaign())
                {
                    var existCampaign = product.GetCampaign();

                    if (existCampaign.HasDuration(systemTime) && !existCampaign.HasTargetSalesCountExceed(quantity))
                    {
                        existCampaign.IncraseTotalSalesCount(quantity);

                        order.SetCampaign(existCampaign);

                        order.SetSalesPrice(product.Price.Value);

                        OrderList.Add(order);
                        Logger.Log($"Order created; product {product.ProductCode.Value}, quantity {quantity}");

                    }
                }
                else
                {
                    order.SetSalesPrice(product.Price.Value);
                    OrderList.Add(order);
                    Logger.Log($"Order created; product {product.ProductCode.Value}, quantity {quantity}");
                }

            }
        }

        public List<OrderDto> GetOrdersByCampaignName(string campaignName) => OrderList.Where(x => x.Campaign?.Name?.Value == campaignName).ToList();

        public List<OrderDto> GetOrders() => OrderList;

        public int GetTotalSalesByCampaign(string campaignName) => GetOrdersByCampaignName(campaignName)?.Sum(x => x.Quantity.Value) ?? 0;

        public double GetAvarageItemPriceByCampaign(string campaignName)
        {
            int totalSales = GetTotalSalesByCampaign(campaignName);
            double salesPrice = GetOrdersByCampaignName(campaignName)?.Sum(x => x.SalesPrice.Value) ?? 0;
            return salesPrice / totalSales;
        }
    }
}
