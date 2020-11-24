using System.ComponentModel.DataAnnotations.Schema;

namespace Database.EFCore.Entities
{
    [Table("Currency")]
    public class CurrencyEntity
    {
        public int Id { get; set; }
        
        public string Name { get; set; } 

    }
}