using FluentAssertions;
using Hepsiburada.CampaignModule.Domain.Campaign;
using Hepsiburada.CampaignModule.Domain.Product;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Hepsiburada.CampaignModule.Domain.Tests.Product
{
    public class ProductDtoTests
    {
        [Fact]
        public void ProductShouldHasStockReturnFalse()
        {
            var product = GetMockData();

            product.Stock.HasStock(0).Should().BeTrue();

            product.Stock.HasStock(1001).Should().BeFalse();
        }
        [Fact]
        public void ProductShouldMakeDiscountIsSuccess()
        {
            var product = GetMockData();

            product.Price.Value.Should().Be(100);

            product.SetCampaign(new CampaignDto("c1", product, 10, 10, 980));

            product.MakeDiscount(-5);

            product.Price.Value.Should().Be(95);
        }
        [Fact]
        public void ProductShouldMakeDiscountIsFail()
        {
            var product = GetMockData();

            product.Price.Value.Should().Be(100);

            product.SetCampaign(new CampaignDto("c1", product, 10, 10, 980));

            product.MakeDiscount(-80);

            product.Price.Value.Should().Be(100);
        }
        private ProductDto GetMockData()
        {
            var product = new ProductDto("p1", 100, 1000);

            return product;
        }
    }
}
