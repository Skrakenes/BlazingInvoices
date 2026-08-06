using System.ComponentModel.DataAnnotations;

namespace BlazingInvoices.Models;

public class SettingsModel
{
    [Required, MaxLength(200)]
    public string BuisnessName { get; set; }

    [Required, EmailAddress, MaxLength(200)]
    public string EmailId { get; set; }

    [MaxLength(15)]
    public string? ContactNumber { get; set; }

    [MaxLength(250)]
    public string? Address { get; set; }

    public double TaxPercentage { get; set; }
}