using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class StorageRoomInInventory : BaseEntity
{
    [Display(Name = nameof(CreatedAt), Prompt = nameof(CreatedAt), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime CreatedAt { get; set; }
    
    
    
    [Display(Name = nameof(EndedAt), Prompt = nameof(EndedAt), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime? EndedAt { get; set; }
    
    
    
    [Display(Name = nameof(Inventory), Prompt = nameof(Inventory), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid InventoryId { get; set; }
    
    [Display(Name = nameof(Inventory), Prompt = nameof(Inventory), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Inventory? Inventory { get; set; }
    
    
    
    [Display(Name = nameof(StorageRoom), Prompt = nameof(StorageRoom), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid StorageRoomId { get; set; }
    
    [Display(Name = nameof(StorageRoom), Prompt = nameof(StorageRoom), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public StorageRoom? StorageRoom { get; set; }
}