using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Base.Domain;

namespace App.Domain;

public class StorageRoom : BaseEntity
{
    [MaxLength(128)]
    [Display(Name = nameof(Name), Prompt = nameof(Name), ResourceType = typeof(App.Resources.Domain.StorageRoom))]
    public string Name { get; set; } = default!;
    
    
    
    [MaxLength(255)]
    [Display(Name = nameof(Location), Prompt = nameof(Location), ResourceType = typeof(App.Resources.Domain.StorageRoom))]
    public string Location { get; set; } = default!;
    
    
    
    [Display(Name = nameof(LastUpdated), Prompt = nameof(LastUpdated), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime LastUpdated { get; set; }
    
    
    
    [Display(Name = nameof(CreatedAt), Prompt = nameof(CreatedAt), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime CreatedAt { get; set; }
    
    
    
    [Display(Name = nameof(EndedAt), Prompt = nameof(EndedAt), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime? EndedAt { get; set; }
    
    
    
    [Display(Name = nameof(StockAudits), Prompt = nameof(StockAudits), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public ICollection<StockAudit>? StockAudits { get; set; }
    
    
    
    [Display(Name = nameof(StorageRoomInInventories), Prompt = nameof(StorageRoomInInventories), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public ICollection<StorageRoomInInventory>? StorageRoomInInventories { get; set; }
    
    
    
    [Display(Name = nameof(ProductInStorageRooms), Prompt = nameof(ProductInStorageRooms), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public ICollection<ProductInStorageRoom>? ProductInStorageRooms { get; set; }
    
    
    
    [Display(Name = nameof(CurrentStocks), Prompt = nameof(CurrentStocks), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public ICollection<CurrentStock>? CurrentStocks { get; set; }
    
    
    
    [Display(Name = nameof(FromStockMovement), Prompt = nameof(FromStockMovement), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    [InverseProperty("FromStorageRoom")]
    public ICollection<StockMovement>? FromStockMovement { get; set; } //fromstockmovements
    
    
    
    [Display(Name = nameof(ToStockMovement), Prompt = nameof(ToStockMovement), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    [InverseProperty("ToStorageRoom")]
    public ICollection<StockMovement>? ToStockMovement { get; set; }
}