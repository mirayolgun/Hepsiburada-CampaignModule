using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Hepsiburada.CampaignModule.Domain.ValueObjects;
using FluentAssertions;

namespace Hepsiburada.CampaignModule.Domain.Tests.ValueObjects
{
    public class PriceTests
    {
        [Fact]
        public void ShouldBeCreatePriceValue()
        {

            var Price = new Price(1);

            Price.Value.Should().Be(1);

        }
        [Fact]
        public void PriceShouldReturnValueForEqualityComponent()
        {
            var Price = new Price(5);

            var equalityComponent = new List<object> { Price.Value };

            Price.GetEqualityComponents().Should().BeEquivalentTo(equalityComponent);

        }
    }
}
