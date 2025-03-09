using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class Supplier : BaseEntity
{
    [MaxLength(128)]
    [Display(Name = nameof(Name), Prompt = nameof(Name), ResourceType = typeof(App.Resources.Domain.Supplier))]
    public string Name { get; set; } = default!;
    
    
    
    [MaxLength(20)]
    [Display(Name = nameof(TelephoneNr), Prompt = nameof(TelephoneNr), ResourceType = typeof(App.Resources.Domain.Supplier))]
    public string TelephoneNr { get; set; } = default!;
    
    
    
    [MaxLength(128)]
    [Display(Name = nameof(Email), Prompt = nameof(Email), ResourceType = typeof(App.Resources.Domain.Supplier))]
    public string Email { get; set; } = default!;
    
    
    
    [Display(Name = nameof(CreatedAt), Prompt = nameof(CreatedAt), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime CreatedAt { get; set; }
    
    
    
    [Display(Name = nameof(Address), Prompt = nameof(Address), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid AddressId { get; set; }
    
    [Display(Name = nameof(Address), Prompt = nameof(Address), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Address? Address { get; set; }
    
    
    
    [Display(Name = nameof(Actions), Prompt = nameof(Actions), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public ICollection<ActionEntity>? Actions { get; set; }
}