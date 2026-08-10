using System.ComponentModel.DataAnnotations;

namespace BlazingInvoices.Data;

public class Service
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }
    public decimal Rate { get; set; }

    [Required, MaxLength(30)]
    public string Unit { get; set; }

    [Required, MaxLength(250)]
    public string Description { get; set; }

    [Required]
    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
}
