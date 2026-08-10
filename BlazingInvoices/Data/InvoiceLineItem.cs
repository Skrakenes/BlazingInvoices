using System.ComponentModel.DataAnnotations;

namespace BlazingInvoices.Data;

public class InvoiceLineItem
{
    [Key]
    public long Id { get; set; }

    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }

    public int? ServiceId { get; set; }
    public virtual Service? Service { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }
    public decimal Rate { get; set; }

    [Required, MaxLength(30)]
    public string Unit { get; set; }

    public int Quantity { get; set; }

}
