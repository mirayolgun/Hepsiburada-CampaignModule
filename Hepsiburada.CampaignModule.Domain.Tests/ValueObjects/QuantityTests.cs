using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Hepsiburada.CampaignModule.Domain.ValueObjects;
using FluentAssertions;

namespace Hepsiburada.CampaignModule.Domain.Tests.ValueObjects
{
    public class QuantityTests
    {
        [Fact]
        public void ShouldBeCreateQuantityValue()
        {

            var Quantity = new Quantity(1);

            Quantity.Value.Should().Be(1);

        }
        [Fact]
        public void Quantity_ShouldReturn_Value_For_EqualityComponent()
        {
            var Quantity = new Quantity(5);

            var equalityComponent = new List<object> { Quantity.Value };

            Quantity.GetEqualityComponents().Should().BeEquivalentTo(equalityComponent);

        }
    }
}
