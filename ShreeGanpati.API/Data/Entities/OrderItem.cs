using System.ComponentModel.DataAnnotations;

namespace ShreeGanpati.API.Data.Entities;

public class OrderItem
{
    [Key]
    public long Id { get; set; }
    public string OrderId { get; set; }
    public int JewelleryId { get; set; }
    [Required, MinLength(50)]
    public string Name { get; set; }

    [Range(0.1, double.MaxValue)]
    public double Price { get; set; }

    [Range(1, double.MaxValue)]
    public int Quantity { get; set; }

    [Required, MaxLength(50)]
    public string Metel { get; set; }

    [Required, MaxLength(50)]
    public string AddOns { get; set; }
    
    [Range(0.1, double.MaxValue)]
    public double TotalPrice { get; set; }
    public virtual Order Order { get; set; }


}