using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class CurrentStock : BaseEntity
{
    [Display(Name = nameof(Quantity), Prompt = nameof(Quantity), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public decimal Quantity { get; set; }
    
    
    
    [Display(Name = nameof(LastUpdated), Prompt = nameof(LastUpdated), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime LastUpdated { get; set; }
    
    
    
    [Display(Name = nameof(Product), Prompt = nameof(Product), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid ProductId { get; set; }
    
    [Display(Name = nameof(Product), Prompt = nameof(Product), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Product? Product { get; set; }
    
    
    
    [Display(Name = nameof(StorageRoom), Prompt = nameof(StorageRoom), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid StorageRoomId { get; set; }
    
    [Display(Name = nameof(StorageRoom), Prompt = nameof(StorageRoom), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public StorageRoom? StorageRoom { get; set; }
}