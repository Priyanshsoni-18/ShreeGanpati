using System.ComponentModel.DataAnnotations;

namespace ShreeGanpati.API.Data.Entities;

public class JewelleryOption
{
    public int JewelleryId { get; set; }

    [Required, MaxLength(50)]
    public string Metel { get; set; }

    [Required, MaxLength(50)]
    public string AddOns { get; set; }

    public virtual Jewellery Jewellery { get; set; }
}
