using FluentAssertions;
using Hepsiburada.CampaignModule.Domain.Campaign;
using Hepsiburada.CampaignModule.Domain.Order;
using Hepsiburada.CampaignModule.Domain.Product;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Hepsiburada.CampaignModule.Domain.Tests.Campaign
{
    public class CampaignServiceTests
    {
        private readonly ICampaignService campaignService;
        private readonly IProductService productService;

        public CampaignServiceTests()
        {
            productService = new ProductService();
            Init();
            this.campaignService = new CampaignService(new OrderService());
        }

        [Fact]
        public void CampaignService_Should_AddNewCampaign()
        {
            var product = productService.GetProduct("p1");

            campaignService.AddCampaing("c1", product, 10, 20, 100);

            var campaign = campaignService.GetCampaignInfo("c1");

            campaign.Count.Value.Should().Be(100);

            campaign.Limit.Value.Should().Be(20);

            campaign.Duration.Value.Should().Be(10);

            campaign.Name.Value.Should().Be("c1");

            campaign.Product.ProductCode.Value.Should().Be("p1");
        }
        [Fact]
        public void CampaignService_Should_ThrowLogicException_CampaignAlreadyExists()
        {
            var product = productService.GetProduct("p1");

            campaignService.AddCampaing("c1", product, 10, 20, 100);

            Assert.Throws<LogicException>(() =>
            {
                campaignService.AddCampaing("c1", product, 10, 20, 100);
            });
        }
        [Fact]
        public void CampaignService_Should_GetCampaignByProductCode_IsSuccess()
        {
            var product = productService.GetProduct("p1");

            campaignService.AddCampaing("c1", product, 10, 20, 100);

            var campaign = campaignService.GetCampaignByProductCode("p1");

            campaign.Count.Value.Should().Be(100);

            campaign.Limit.Value.Should().Be(20);

            campaign.Duration.Value.Should().Be(10);

            campaign.Name.Value.Should().Be("c1");

            campaign.Product.ProductCode.Value.Should().Be("p1");
        }

        private void Init()
        {
            productService.AddProduct("p1", 100, 1000);
        }


    }
}
