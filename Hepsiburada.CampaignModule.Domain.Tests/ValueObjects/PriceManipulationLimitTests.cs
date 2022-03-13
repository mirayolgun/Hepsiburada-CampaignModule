using System;
using System.Collections.Generic;
using Hepsiburada.CampaignModule.Domain.ValueObjects;
using System.Text;
using Xunit;
using FluentAssertions;

namespace Hepsiburada.CampaignModule.Domain.Tests.ValueObjects
{
    public class PriceManipulationLimitTests
    {
        [Fact]
        public void ShouldBeCreatePriceManipulationLimitValue()
        {

            var PriceManipulationLimit = new PriceManipulationLimit(1);

            PriceManipulationLimit.Value.Should().Be(1);

        }
        [Fact]
        public void PriceManipulationLimitShouldReturnValueForEqualityComponent()
        {
            var PriceManipulationLimit = new PriceManipulationLimit(5);

            var equalityComponent = new List<object> { PriceManipulationLimit.Value };

            PriceManipulationLimit.GetEqualityComponents().Should().BeEquivalentTo(equalityComponent);

        }
    }
}
