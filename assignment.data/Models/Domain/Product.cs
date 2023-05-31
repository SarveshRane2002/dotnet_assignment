
using System.ComponentModel.DataAnnotations;

namespace assignment.data.Models.Domain;

public class Product
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Description { get; set; }
    public string? Image { get; set; }
    public decimal?  Price { get; set; }
    
}
