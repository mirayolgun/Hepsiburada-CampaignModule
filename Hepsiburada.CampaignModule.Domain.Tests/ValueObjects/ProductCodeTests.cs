using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Hepsiburada.CampaignModule.Domain.ValueObjects;
using Xunit;

namespace Hepsiburada.CampaignModule.Domain.Tests.ValueObjects
{
    public class ProductCodeTests
    {
        [Fact]
        public void ShouldBeCreateProductCodeValue()
        {

            var ProductCode = new ProductCode("p1");

            ProductCode.Value.Should().Be("p1");

        }
        [Fact]
        public void ProductCodeShouldReturnValueForEqualityComponent()
        {
            var ProductCode = new ProductCode("p1");

            var equalityComponent = new List<object> { ProductCode.Value };

            ProductCode.GetEqualityComponents().Should().BeEquivalentTo(equalityComponent);

        }
    }
}
