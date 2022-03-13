using FluentAssertions;
using Hepsiburada.CampaignModule.Domain.Campaign;
using Hepsiburada.CampaignModule.Domain.Order;
using Hepsiburada.CampaignModule.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Hepsiburada.CampaignModule.Domain.Tests.Order
{
    public class OrderServiceTests
    {
        private readonly IOrderService orderService;
        public OrderServiceTests()
        {
            this.orderService = new OrderService();
        }

        [Fact]
        public void OrderShouldAdd()
        {
            var product = new ProductDto("p1", 100, 1000);

            orderService.AddOrder(product, 5, new TimeSpan(0, 0, 0));

            var order = orderService.GetOrders().FirstOrDefault(x => x.Product.Id == product.Id);

            order.Product.Should().Be(product);
        }
        [Fact]
        public void OrderShouldCalculateTotalSalesByCampaign()
        {
            var product = new ProductDto("p1", 100, 1000);

            product.SetCampaign(new CampaignDto("c1", product, 10, 20, 10));

            orderService.AddOrder(product, 5, new TimeSpan(0, 0, 0));

            int totalSales = orderService.GetTotalSalesByCampaign("c1");

            totalSales.Should().Be(5);
        }
        [Fact]
        public void OrderShouldCalculateAvarageItemPriceByCampaign()
        {
            var product = new ProductDto("p1", 100, 1000);

            product.SetCampaign(new CampaignDto("c1", product, 10, 20, 10));

            orderService.AddOrder(product, 5, new TimeSpan(0, 0, 0));

            double avarageItemPrice = orderService.GetAvarageItemPriceByCampaign("c1");

            avarageItemPrice.Should().Be(20);
        }
    }
}
