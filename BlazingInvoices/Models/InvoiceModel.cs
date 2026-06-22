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
            },
            new InvoiceModel
{
    Id = 5,
    InvoiceNumber = "INV-2026-005",
    ClientId = 5,
    ClientName = "Katrine Moen",
    IssuedOn = new DateTime(2026, 6, 12),
    DueOn = new DateTime(2026, 6, 26),
    IsPaid = false,
    LineItems = new[]
    {
        new InvoiceLineItemModel { ServiceId = 1, ServiceName = "General Consultation", Rate = 750m, Unit = "per hour", Quantity = 1 },
        new InvoiceLineItemModel { ServiceId = 3, ServiceName = "Maintenance Check", Rate = 500m, Unit = "per visit", Quantity = 1 }
    }
},

new InvoiceModel
{
    Id = 6,
    InvoiceNumber = "INV-2026-006",
    ClientId = 2,
    ClientName = "Marius Håland",
    IssuedOn = new DateTime(2026, 6, 14),
    DueOn = new DateTime(2026, 6, 28),
    IsPaid = true,
    PaidOn = new DateTime(2026, 6, 20),
    LineItems = new[]
    {
        new InvoiceLineItemModel { ServiceId = 7, ServiceName = "Custom Development", Rate = 1200m, Unit = "per hour", Quantity = 2 }
    }
},

new InvoiceModel
{
    Id = 7,
    InvoiceNumber = "INV-2026-007",
    ClientId = 1,
    ClientName = "Anna Solberg",
    IssuedOn = new DateTime(2026, 6, 18),
    DueOn = new DateTime(2026, 7, 2),
    IsPaid = false,
    LineItems = new[]
    {
        new InvoiceLineItemModel { ServiceId = 4, ServiceName = "Emergency Support", Rate = 2000m, Unit = "per incident", Quantity = 1 }
    }
},

new InvoiceModel
{
    Id = 8,
    InvoiceNumber = "INV-2026-008",
    ClientId = 3,
    ClientName = "Elise Nystuen",
    IssuedOn = new DateTime(2026, 6, 20),
    DueOn = new DateTime(2026, 7, 4),
    IsPaid = true,
    PaidOn = new DateTime(2026, 6, 25),
    LineItems = new[]
    {
        new InvoiceLineItemModel { ServiceId = 2, ServiceName = "Installation Service", Rate = 1500m, Unit = "per job", Quantity = 1 },
        new InvoiceLineItemModel { ServiceId = 1, ServiceName = "General Consultation", Rate = 750m, Unit = "per hour", Quantity = 1 }
    }
},

new InvoiceModel
{
    Id = 9,
    InvoiceNumber = "INV-2026-009",
    ClientId = 4,
    ClientName = "Jonas Vik",
    IssuedOn = new DateTime(2026, 6, 22),
    DueOn = new DateTime(2026, 7, 6),
    IsPaid = false,
    LineItems = new[]
    {
        new InvoiceLineItemModel { ServiceId = 5, ServiceName = "Maintenance Check", Rate = 500m, Unit = "per visit", Quantity = 2 }
    }
},

new InvoiceModel
{
    Id = 10,
    InvoiceNumber = "INV-2026-010",
    ClientId = 5,
    ClientName = "Katrine Moen",
    IssuedOn = new DateTime(2026, 6, 25),
    DueOn = new DateTime(2026, 7, 9),
    IsPaid = true,
    PaidOn = new DateTime(2026, 6, 30),
    LineItems = new[]
    {
        new InvoiceLineItemModel { ServiceId = 6, ServiceName = "Emergency Support", Rate = 2000m, Unit = "per incident", Quantity = 1 },
        new InvoiceLineItemModel { ServiceId = 3, ServiceName = "Maintenance Check", Rate = 500m, Unit = "per visit", Quantity = 1 }
    }
},

new InvoiceModel
{
    Id = 11,
    InvoiceNumber = "INV-2026-011",
    ClientId = 2,
    ClientName = "Marius Håland",
    IssuedOn = new DateTime(2026, 6, 27),
    DueOn = new DateTime(2026, 7, 11),
    IsPaid = false,
    LineItems = new[]
    {
        new InvoiceLineItemModel { ServiceId = 7, ServiceName = "Custom Development", Rate = 1200m, Unit = "per hour", Quantity = 4 }
    }
},

new InvoiceModel
{
    Id = 12,
    InvoiceNumber = "INV-2026-012",
    ClientId = 3,
    ClientName = "Elise Nystuen",
    IssuedOn = new DateTime(2026, 6, 29),
    DueOn = new DateTime(2026, 7, 13),
    IsPaid = true,
    PaidOn = new DateTime(2026, 7, 5),
    LineItems = new[]
    {
        new InvoiceLineItemModel { ServiceId = 1, ServiceName = "General Consultation", Rate = 750m, Unit = "per hour", Quantity = 3 }
    }
},

new InvoiceModel
{
    Id = 13,
    InvoiceNumber = "INV-2026-013",
    ClientId = 1,
    ClientName = "Anna Solberg",
    IssuedOn = new DateTime(2026, 7, 1),
    DueOn = new DateTime(2026, 7, 15),
    IsPaid = false,
    LineItems = new[]
    {
        new InvoiceLineItemModel { ServiceId = 2, ServiceName = "Installation Service", Rate = 1500m, Unit = "per job", Quantity = 1 }
    }
},

new InvoiceModel
{
    Id = 14,
    InvoiceNumber = "INV-2026-014",
    ClientId = 4,
    ClientName = "Jonas Vik",
    IssuedOn = new DateTime(2026, 7, 3),
    DueOn = new DateTime(2026, 7, 17),
    IsPaid = true,
    PaidOn = new DateTime(2026, 7, 8),
    LineItems = new[]
    {
        new InvoiceLineItemModel { ServiceId = 5, ServiceName = "Maintenance Check", Rate = 500m, Unit = "per visit", Quantity = 1 },
        new InvoiceLineItemModel { ServiceId = 7, ServiceName = "Custom Development", Rate = 1200m, Unit = "per hour", Quantity = 1 }
    }
},

    };
    }
}