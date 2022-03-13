using FluentAssertions;
using Hepsiburada.CampaignModule.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Hepsiburada.CampaignModule.Domain.Tests.ValueObjects
{
    public class DurationTests
    {
        [Fact]
        public void ShouldBeCreateDurationValue()
        {

            var duration = new Duration(1);

            duration.Value.Should().Be(1);

        }
        [Fact]
        public void DurationShouldReturnValueForEqualityComponent()
        {
            var duration = new Duration(5);

            var equalityComponent = new List<object> { duration.Value };

            duration.GetEqualityComponents().Should().BeEquivalentTo(equalityComponent);

        }
    }
}