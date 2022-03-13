using System;
using FluentAssertions;
using System.Collections.Generic;
using System.Text;
using Hepsiburada.CampaignModule.Domain.ValueObjects;
using Xunit;

namespace Hepsiburada.CampaignModule.Domain.Tests.ValueObjects
{
    public class NameTests
    {
        [Fact]
        public void ShouldBeCreateNameValue()
        {

            var Name = new Name("c2");

            Name.Value.Should().Be("c2");

        }
        [Fact]
        public void NameShouldReturnValueForEqualityComponent()
        {
            var Name = new Name("c2");

            var equalityComponent = new List<object> { Name.Value };

            Name.GetEqualityComponents().Should().BeEquivalentTo(equalityComponent);

        }
    }
}
