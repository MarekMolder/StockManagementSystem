using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Base.Domain;

namespace App.Domain;

public class Inventory : BaseEntity
{
    [MaxLength(128)]
    [Display(Name = nameof(Name), Prompt = nameof(Name), ResourceType = typeof(App.Resources.Domain.Inventory))]
    public string Name { get; set; } = default!;
    
    
    
    [Display(Name = nameof(LastUpdated), Prompt = nameof(LastUpdated), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime LastUpdated { get; set; }
    
    
    
    [Display(Name = nameof(CreatedAt), Prompt = nameof(CreatedAt), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime CreatedAt { get; set; }
    
    
    
    [Display(Name = nameof(EndedAt), Prompt = nameof(EndedAt), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime? EndedAt { get; set; }
    
    
    
    [Display(Name = nameof(Address), Prompt = nameof(Address), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid AddressId { get; set; }
    
    [Display(Name = nameof(Address), Prompt = nameof(Address), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Address? Address { get; set; }
    
    
    
    [Display(Name = nameof(StorageRoomInInventories), Prompt = nameof(StorageRoomInInventories), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public ICollection<StorageRoomInInventory>? StorageRoomInInventories { get; set; }
    
    
    
    [Display(Name = nameof(FromStockMovements), Prompt = nameof(FromStockMovements), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    [InverseProperty("FromInventory")]
    public ICollection<StockMovement>? FromStockMovements { get; set; }
    
    
    
    [Display(Name = nameof(ToStockMovements), Prompt = nameof(ToStockMovements), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    [InverseProperty("ToInventory")]
    public ICollection<StockMovement>? ToStockMovements { get; set; }
}