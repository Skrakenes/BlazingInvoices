using System.ComponentModel.DataAnnotations;

namespace BlazingInvoices.Models;

public class ClientModel
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; }

    [Required, EmailAddress, MaxLength(150)]
    public string EmailId { get; set; }

    [Required, MaxLength(15)]
    public string ContactNumber { get; set; }
    public string? Remarks { get; set; }

    public static IEnumerable<ClientModel> GetSeedData()
    {
        return new[]
        {
        new ClientModel
        {
            Id = 1,
            Name = "Anna Solberg",
            EmailId = "anna.solberg@example.com",
            ContactNumber = "+47 91234567",
            Remarks = "Prefers email communication."
        },
        new ClientModel
        {
            Id = 2,
            Name = "Marius Håland",
            EmailId = "marius.haland@example.com",
            ContactNumber = "+47 99887766",
            Remarks = "Requested follow‑up next month."
        },
        new ClientModel
        {
            Id = 3,
            Name = "Elise Nystuen",
            EmailId = "elise.nystuen@example.com",
            ContactNumber = "+47 93445566",
            Remarks = "Long‑term client, stable cooperation."
        },
        new ClientModel
        {
            Id = 4,
            Name = "Jonas Vik",
            EmailId = "jonas.vik@example.com",
            ContactNumber = "+47 90011223",
            Remarks = "Interested in premium service package."
        },
        new ClientModel
        {
            Id = 5,
            Name = "Katrine Moen",
            EmailId = "katrine.moen@example.com",
            ContactNumber = "+47 95566778",
            Remarks = null
        }
    };
    }

}
