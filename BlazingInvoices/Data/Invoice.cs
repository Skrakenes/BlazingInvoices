using System.ComponentModel.DataAnnotations;

namespace BlazingInvoices.Data;

public class Invoice
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(10)]
    public string InvoiceNumber { get; set; }

    public int? ClientId { get; set; }
    public virtual Client? Client { get; set; }


    #region ------- Client -------
    [Required, MaxLength(100)]
    public string ClientName { get; set; }

    [Required, EmailAddress, MaxLength(150)]
    public string ClientEmailId { get; set; }

    [Required, MaxLength(15)]
    public string ClientContactNumber { get; set; }
    #endregion

    #region ---- Our Business Info ----
    [Required, MaxLength(200)]
    public string BuisnessName { get; set; }

    [Required, EmailAddress, MaxLength(200)]
    public string BusinessEmailId { get; set; }

    [MaxLength(15)]
    public string? BusinessContactNumber { get; set; }

    [MaxLength(250)]
    public string? BusinessAddress { get; set; }

    public double TaxPercentage { get; set; }
    #endregion

    public DateTime IssuedOn { get; set; }
    public DateTime? DueOn { get; set; }
    public bool IsPaid { get; set; }
    public DateTime? PaidOn { get; set; }

    [MaxLength(250)]
    public string? Notes { get; set; }
    public ICollection<InvoiceLineItem> LineItems { get; set; } = [];

    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
}
