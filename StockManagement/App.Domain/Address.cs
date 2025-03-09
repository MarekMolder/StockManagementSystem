using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class Address : BaseEntity
{
    [MaxLength(255)]
    [Display(Name = nameof(StreetName), Prompt = nameof(StreetName), ResourceType = typeof(App.Resources.Domain.Address))]
    public string StreetName { get; set; } = default!;
    
    
    
    [Display(Name = nameof(BuildingNr), Prompt = nameof(BuildingNr), ResourceType = typeof(App.Resources.Domain.Address))]
    public int BuildingNr { get; set; }
    
    
    
    [MaxLength(255)]
    [Display(Name = nameof(City), Prompt = nameof(City), ResourceType = typeof(App.Resources.Domain.Address))]
    public string City { get; set; } = default!;
    
    
    
    [MaxLength(255)]
    [Display(Name = nameof(Province), Prompt = nameof(Province), ResourceType = typeof(App.Resources.Domain.Address))]
    public string Province { get; set; } = default!;
    
    
    
    [MaxLength(255)]
    [Display(Name = nameof(Country), Prompt = nameof(Country), ResourceType = typeof(App.Resources.Domain.Address))]
    public string Country { get; set; } = default!;
    
    
    
    [MaxLength(255)]
    [Display(Name = nameof(Name), Prompt = nameof(Name), ResourceType = typeof(App.Resources.Domain.Address))]
    public string Name { get; set; } = default!;
    
    
    [Display(Name = nameof(UnitNr), Prompt = nameof(UnitNr), ResourceType = typeof(App.Resources.Domain.Address))]
    public int? UnitNr { get; set; }
    
    
    
    [Display(Name = nameof(CreatedAt), Prompt = nameof(CreatedAt), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime CreatedAt { get; set; }
    
    
    
    [Display(Name = nameof(Inventories), Prompt = nameof(Inventories), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public ICollection<Inventory>? Inventories { get; set; }
    
    
    
    [Display(Name = nameof(Suppliers), Prompt = nameof(Suppliers), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public ICollection<Supplier>? Suppliers { get; set; }
}