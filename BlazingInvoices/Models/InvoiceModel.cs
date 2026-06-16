namespace BlazingInvoices.Models;

public class InvoiceModel
{
    public int Id { get; set; }
    public string InvoiceNumber { get; set; }
    public int ClientId { get; set; }
    public string ClientName { get; set; }

    public DateTime IssuedOn { get; set; }
    public DateTime? DueOn { get; set; }
    public bool IsPaid { get; set; }
    public DateTime? PaidOn { get; set; }
    public string Status => IsPaid ? "Paid" : "Pending";

    public IEnumerable<InvoiceLineItemModel> LineItems { get; set; } = [];
    public decimal TotalAmount => LineItems.Sum(l => l.Amount);

}

public class InvoiceLineItemModel
{
    public int ServiceId { get; set; }
    public string ServiceName { get; set; }
    public decimal Rate { get; set; }
    public string Unit { get; set; }
    public int Quantity { get; set; }

    public decimal Amount => Rate * Quantity;
}

public static class InvoiceSeeder
{
    public static IEnumerable<InvoiceModel> GetSeedInvoices()
    {
        return new List<InvoiceModel>
        {
            new InvoiceModel
            {
                Id = 1,
                InvoiceNumber = "INV-2026-001",
                ClientId = 1,
                ClientName = "Anna Solberg",
                IssuedOn = new DateTime(2026, 5, 10),
                DueOn = new DateTime(2026, 5, 24),
                IsPaid = true,
                PaidOn = new DateTime(2026, 5, 20),
                LineItems = new[]
                {
                    new InvoiceLineItemModel
                    {
                        ServiceId = 1,
                        ServiceName = "General Consultation",
                        Rate = 750m,
                        Unit = "per hour",
                        Quantity = 2
                    },
                    new InvoiceLineItemModel
                    {
                        ServiceId = 2,
                        ServiceName = "Report Preparation",
                        Rate = 500m,
                        Unit = "per job",
                        Quantity = 1
                    }
                }
            },

            new InvoiceModel
            {
                Id = 2,
                InvoiceNumber = "INV-2026-002",
                ClientId = 2,
                ClientName = "Marius Håland",
                IssuedOn = new DateTime(2026, 5, 15),
                DueOn = new DateTime(2026, 5, 29),
                IsPaid = false,
                PaidOn = null,
                LineItems = new[]
                {
                    new InvoiceLineItemModel
                    {
                        ServiceId = 3,
                        ServiceName = "Installation Service",
                        Rate = 1500m,
                        Unit = "per job",
                        Quantity = 1
                    },
                    new InvoiceLineItemModel
                    {
                        ServiceId = 4,
                        ServiceName = "Travel Fee",
                        Rate = 300m,
                        Unit = "per trip",
                        Quantity = 1
                    }
                }
            },

            new InvoiceModel
            {
                Id = 3,
                InvoiceNumber = "INV-2026-003",
                ClientId = 3,
                ClientName = "Elise Nystuen",
                IssuedOn = new DateTime(2026, 6, 1),
                DueOn = new DateTime(2026, 6, 15),
                IsPaid = false,
                PaidOn = null,
                LineItems = new[]
                {
                    new InvoiceLineItemModel
                    {
                        ServiceId = 5,
                        ServiceName = "Maintenance Check",
                        Rate = 500m,
                        Unit = "per visit",
                        Quantity = 1
                    },
                    new InvoiceLineItemModel
                    {
                        ServiceId = 6,
                        ServiceName = "Emergency Support",
                        Rate = 2000m,
                        Unit = "per incident",
                        Quantity = 1
                    }
                }
            },

            new InvoiceModel
            {
                Id = 4,
                InvoiceNumber = "INV-2026-004",
                ClientId = 4,
                ClientName = "Jonas Vik",
                IssuedOn = new DateTime(2026, 6, 5),
                DueOn = new DateTime(2026, 6, 19),
                IsPaid = true,
                PaidOn = new DateTime(2026, 6, 10),
                LineItems = new[]
                {
                    new InvoiceLineItemModel
                    {
                        ServiceId = 7,
                        ServiceName = "Custom Development",
                        Rate = 1200m,
                        Unit = "per hour",
                        Quantity = 3
                    }
                }
        }
    };
    }
}