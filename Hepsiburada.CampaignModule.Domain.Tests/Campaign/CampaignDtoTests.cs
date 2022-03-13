using FluentAssertions;
using Hepsiburada.CampaignModule.Domain.Campaign;
using Hepsiburada.CampaignModule.Domain.Product;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Hepsiburada.CampaignModule.Domain.Tests.Campaign
{
    public class CampaignDtoTests
    {
        [Fact]
        public void Campaign_Should_HasTargetSalesCountExceed_ReturnFalse()
        {
            var campaign = GetMockData();

            campaign.HasTargetSalesCountExceed(20).Should().BeFalse();
        }
        [Fact]
        public void Campaign_Should_IncraseTargetSalesCount_Incrase()
        {
            var campaign = GetMockData();

            campaign.TotalSalesCount.Should().Be(0);

            campaign.IncraseTotalSalesCount(5);

            campaign.TotalSalesCount.Should().Be(5);
        }
        [Fact]
        public void Campaign_Should_StatusPassive()
        {
            var campaign = GetMockData();

            campaign.GetStatusString().Should().Be("Active");

            campaign.CampaignClose();

            campaign.GetStatusString().Should().Be("Passive");
        }
        [Fact]
        public void Campaign_Should_IsPriceManipulationLimitExceed_ReturnFalse()
        {
            var campaign = GetMockData();

            campaign.IsPriceManipulationLimitExceed().Should().BeFalse();

            campaign.Product.Price.SetPrice(70);

            campaign.IsPriceManipulationLimitExceed().Should().BeTrue();
        }
        [Fact]
        public void Campaign_Should_HasDuration_ReturnFalse()
        {
            var campaign = GetMockData();

            campaign.HasDuration(new TimeSpan(5, 0, 0)).Should().BeTrue();

            campaign.HasDuration(new TimeSpan(11, 0, 0)).Should().BeFalse();
        }
        private CampaignDto GetMockData()
        {
            var product = new ProductDto("p1", 100, 1000);

            return new CampaignDto("c1", product, 10, 10, 980);
        }

    }
}
