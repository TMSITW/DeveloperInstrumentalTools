using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.EFCore.Entities
{    
    [Table("Rate")]
    public class ExchangeRateEntity
    {
        public int Id { get; set; }
        
        public CurrencyEntity Currency { get; set; }
                
        public DateTime Date { get; set; }
        
        public double Value { get; set; }
    }
}