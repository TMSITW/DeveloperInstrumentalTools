using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace UnitTestsTarget
{
    public class DayOfWeekService : IDayOfWeekService
    {
        private static IReadOnlyCollection<DayOfWeek> Weekend { get; } = new[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
        
        public bool IsWeekend(in DateTime date)
        {
            return Weekend.Contains(CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(date));
        }
    }
}