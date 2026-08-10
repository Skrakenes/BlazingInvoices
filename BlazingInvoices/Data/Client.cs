using System.ComponentModel.DataAnnotations;

namespace BlazingInvoices.Data;

public class Client
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    [Required, EmailAddress, MaxLength(150)]
    public string EmailId { get; set; }

    [Required, MaxLength(15)]
    public string ContactNumber { get; set; }
    public string? Remarks { get; set; }

    [Required]
    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
}
