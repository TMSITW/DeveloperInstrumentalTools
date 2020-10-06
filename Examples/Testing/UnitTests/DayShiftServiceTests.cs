using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using UnitTestsTarget;

namespace UnitTests
{
    public class DayShiftServiceTests
    {
        private readonly DateTime friday = new DateTime(2020, 10, 02);
        private readonly DateTime monday = new DateTime(2020, 10, 05);
        private readonly DateTime tuesday = new DateTime(2020, 10, 06);

        
        IDayShiftService service;// = new DayShiftService(dayOfWeekService);

        [SetUp]
        public void SetUp()
        {
            IDayOfWeekService dayOfWeekService = new DayOfWeekService();
            service = new DayShiftService(dayOfWeekService);    
        }
        
        [Test]
        public void GetShiftBusinessDay_RealLogic_MondayToTuesday()
        {
            var actual = service.GetShiftBusinessDay(monday, 1);

            actual.Should().Be(tuesday);
        }
        
        [Test]
        public void GetShiftBusinessDay_RealLogic_TuesdayToMonday()
        {
            var actual = service.GetShiftBusinessDay(tuesday, -1);

            actual.Should().Be(monday);
        }
        
        [Test]
        public void GetShiftBusinessDay_RealLogic_FridayToMonday()
        {
            var actual = service.GetShiftBusinessDay(friday, 1);

            actual.Should().Be(monday);
        }
        
        [Test]
        public void GetShiftBusinessDay_RealLogic_MondayToFriday()
        {
            var actual = service.GetShiftBusinessDay(monday, -1);

            actual.Should().Be(friday);
        }
    }
}