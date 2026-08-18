using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlazingInvoices.Data;
// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [Required, MaxLength(50)]
    public string Name { get; set; }

    [Required, MaxLength(200)]
    public string BusinessName { get; set; }

    [Required, EmailAddress, MaxLength(200)]
    public string BusinessEmailId { get; set; }

    [MaxLength(15)]
    public string? BusinessContactNumber { get; set; }

    [MaxLength(250)]
    public string? BusinessAddress { get; set; }

    public double TaxPercentage { get; set; }
}
