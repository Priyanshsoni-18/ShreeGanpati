using System.ComponentModel.DataAnnotations;

namespace ShreeGanpati.API.Data.Entities;

public class Order 
{
    [Key]
    public long Id { get; set; }
    public DateTime OrderAt { get; set; } = DateTime.Now;

    public Guid CustomerId { get; set; }
    [Required, MaxLength(30)] 
    public String CustomerName { get; set; }
    [Required, MaxLength(100)]
    public String CustomerEmail { get; set; }
    [Required, MaxLength(150)]
    public String CustomerAddress { get; set; }

    public double TotalPrice { get; set; }

    public virtual ICollection<OrderItem> Items { get; set; }
}
