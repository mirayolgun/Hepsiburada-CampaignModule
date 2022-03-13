using FluentAssertions;
using Hepsiburada.CampaignModule.Domain.Order;
using Hepsiburada.CampaignModule.Domain.Product;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Hepsiburada.CampaignModule.Domain.Tests.Order
{
    public class OrderDtoTests
    {
        [Fact]
        public void Order_Should_SalesPrice_Set()
        {
            //arrange
            var order = GetMockData();
            //actual
            order.SetSalesPrice(50);
            //expected
            order.SalesPrice.Value.Should().Be(50);
        }
        public OrderDto GetMockData()
        {
            var product = new ProductDto("p1", 100, 1000);

            return new OrderDto(product, 4);
        }
    }
}
