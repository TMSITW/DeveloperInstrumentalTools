using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using UnitTestsTarget;

namespace UnitTests
{
    public class DayOfWeekServiceTests
    {
        [Test]
        public void IsWeekend_Sunday_True()
        {
            var service = new DayOfWeekService();
            const bool expected = true;
            
            var sunday = new DateTime(2020, 10, 03);
            var actual = service.IsWeekend(sunday);

            actual.Should().Be(expected);
        }
        
        [Test]
        public void IsWeekend_Monday_False()
        {
            const bool expected = false;
            var service = new DayOfWeekService();
            
            var monday = new DateTime(2020, 10, 02);
            var actual = service.IsWeekend(monday);

            actual.Should().Be(expected);
        }

    }
}