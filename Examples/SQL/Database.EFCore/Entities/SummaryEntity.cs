using System.ComponentModel.DataAnnotations.Schema;

namespace Database.EFCore.Entities
{
    public class SummaryEntity
    {
        public int Id { get; set; }
        
        public string Code { get; set; }
    }
}