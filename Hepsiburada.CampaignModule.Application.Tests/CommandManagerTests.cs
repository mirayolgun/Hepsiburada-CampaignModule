using FluentAssertions;
using Hepsiburada.CampaignModule.Domain.Campaign;
using Hepsiburada.CampaignModule.Domain.Order;
using Hepsiburada.CampaignModule.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Hepsiburada.CampaignModule.Application.Tests
{
    public class CommandManagerTests
    {
        private IProductService productService;
        private IOrderService orderService;
        private ICampaignService campaignService;
        private ICommand command;
        [Fact]
        public void ShouldCreateProduct()
        {
            command = GetManager();

            command.Execute("create_product", new string[] { "p1", "100", "1000" });

            var product = productService.GetProduct("p1");

            product.Price.Value.Should().Be(100);

            product.Stock.Value.Should().Be(1000);

        }
        [Fact]
        public void ShouldGetProductInfo()
        {
            command = GetManager();

            command.Execute("create_product", new string[] { "p1", "100", "1000" });

            //logs on console
            command.Execute("get_product_info", new string[] { "p1" });

            var product = productService.GetProduct("p1");

            product.Price.Value.Should().Be(100);

            product.Stock.Value.Should().Be(1000);
        }
        [Fact]
        public void ShouldCreateOrder()
        {
            command = GetManager();

            command.Execute("create_product", new string[] { "p1", "100", "1000" });

            //logs on console
            command.Execute("create_order", new string[] { "p1", "4" });

            var order = orderService.GetOrders().FirstOrDefault();

            order.Product.ProductCode.Value.Should().Be("p1");

            order.Product.Price.Value.Should().Be(100);

            order.Product.Stock.Value.Should().Be(996);

            order.Quantity.Value.Should().Be(4);
        }

        [Fact]
        public void ShouldCreateCampaign()
        {
            command = GetManager();

            command.Execute("create_product", new string[] { "p1", "100", "1000" });

            //logs on console
            command.Execute("create_campaign", new string[] { "c1", "p1", "10", "20", "100" });

            var campaign = campaignService.GetCampaignInfo("c1");

            campaign.Product.ProductCode.Value.Should().Be("p1");

            campaign.Limit.Value.Should().Be(20);

            campaign.Count.Value.Should().Be(100);

            campaign.Duration.Value.Should().Be(10);
        }

        [Fact]
        public void ShouldGetCampaignInfo()
        {
            command = GetManager();

            command.Execute("create_product", new string[] { "p1", "100", "1000" });

            //logs on console
            command.Execute("create_campaign", new string[] { "c1", "p1", "10", "20", "100" });

            //logs on console
            command.Execute("get_campaign_info", new string[] { "c1", "p1", "10", "20", "100" });

            var campaign = campaignService.GetCampaignInfo("c1");

            campaign.Product.ProductCode.Value.Should().Be("p1");

            campaign.Limit.Value.Should().Be(20);

            campaign.Count.Value.Should().Be(100);

            campaign.Duration.Value.Should().Be(10);
        }

        [Fact]
        public void ShouldIncareTime()
        {
            command = GetManager();

            var currentTime = command.GetTime();

            currentTime.Should().Be(new TimeSpan(0, 0, 0));
            //logs on console
            command.Execute("increase_time", new string[] { "1" });

            currentTime = command.GetTime();

            currentTime.Should().Be(new TimeSpan(1, 0, 0));

        }
        private CommandManager GetManager()
        {
            productService = new ProductService();
            orderService = new OrderService();
            campaignService = new CampaignService(orderService);
            return new CommandManager(productService, campaignService, orderService);
        }



    }
}
