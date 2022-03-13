using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Hepsiburada.CampaignModule.Domain.ValueObjects;
using FluentAssertions;

namespace Hepsiburada.CampaignModule.Domain.Tests.ValueObjects
{
    public class TargetSalesCountTests
    {
        [Fact]
        public void ShouldBeCreateTargetSalesCountValue()
        {

            var TargetSalesCount = new TargetSalesCount(1);

            TargetSalesCount.Value.Should().Be(1);

        }
        [Fact]
        public void TargetSalesCount_ShouldReturn_Value_For_EqualityComponent()
        {
            var TargetSalesCount = new TargetSalesCount(5);

            var equalityComponent = new List<object> { TargetSalesCount.Value };

            TargetSalesCount.GetEqualityComponents().Should().BeEquivalentTo(equalityComponent);

        }
    }
}
