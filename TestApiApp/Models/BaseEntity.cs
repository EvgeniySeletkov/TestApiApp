using System.ComponentModel.DataAnnotations;

namespace TestApiApp.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
