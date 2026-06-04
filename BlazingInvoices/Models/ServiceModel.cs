using System.ComponentModel.DataAnnotations;

namespace BlazingInvoices.Models;

public class ServiceModel
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; }
    public decimal Rate { get; set; }

    [Required, MaxLength(30)]
    public string Unit { get; set; }

    [Required, MaxLength(250)]
    public string Description { get; set; }

    public ServiceModel? Clone() => MemberwiseClone() as ServiceModel;

    internal static IEnumerable<ServiceModel> GetSeedData()
    {
        return new List<ServiceModel>
            {
        new ServiceModel
        {
            Id = 1,
            Name = "General Consultation",
            Rate = 750m,
            Unit = "per hour",
            Description = "Standard consultation covering assessment, guidance, and professional recommendations."
        },
        new ServiceModel
        {
            Id = 2,
            Name = "Installation Service",
            Rate = 1500m,
            Unit = "per job",
            Description = "Full installation service including setup, configuration, and verification."
        },
        new ServiceModel
        {
            Id = 3,
            Name = "Maintenance Check",
            Rate = 500m,
            Unit = "per visit",
            Description = "Routine maintenance check to ensure optimal performance and identify potential issues."
        },
        new ServiceModel
        {
            Id = 4,
            Name = "Emergency Support",
            Rate = 2000m,
            Unit = "per incident",
            Description = "Priority emergency support with rapid response and issue resolution."
        },
        new ServiceModel
        {
            Id = 5,
            Name = "Custom Development",
            Rate = 1200m,
            Unit = "per hour",
            Description = "Tailored development work based on client requirements and specifications."
        }
    };
    }
}
