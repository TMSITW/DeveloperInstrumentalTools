using System;

namespace WebApplication.EFCore
{
    public class ExchangeRate
    {
        public DateTime Date { get; set; }

        public double Value { get; set; }

        public string Currency { get; set; }
    }
}