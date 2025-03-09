using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Base.Domain;

namespace App.Domain;

public class StockMovement : BaseEntity
{
    [Display(Name = nameof(Amount), Prompt = nameof(Amount), ResourceType = typeof(App.Resources.Domain.StockMovement))]
    public decimal Amount { get; set; }
    
    
    
    [Display(Name = nameof(CreatedAt), Prompt = nameof(CreatedAt), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime CreatedAt { get; set; }
    
    

    [Display(Name = nameof(Product), Prompt = nameof(Product), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid ProductId { get; set; }
    
    [Display(Name = nameof(Product), Prompt = nameof(Product), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Product? Product { get; set; }

    
    
    [Display(Name = nameof(FromStorageRoom), Prompt = nameof(FromStorageRoom), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid? FromStorageRoomId { get; set; }
    
    [Display(Name = nameof(FromStorageRoom), Prompt = nameof(FromStorageRoom), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public StorageRoom? FromStorageRoom { get; set; }
    
    
    
    [Display(Name = nameof(ToStorageRoom), Prompt = nameof(ToStorageRoom), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid? ToStorageRoomId { get; set; }
    
    [Display(Name = nameof(ToStorageRoom), Prompt = nameof(ToStorageRoom), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public StorageRoom? ToStorageRoom { get; set; }
    
    
    
    [Display(Name = nameof(FromInventory), Prompt = nameof(FromInventory), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid FromInventoryId { get; set; }
    
    [Display(Name = nameof(FromInventory), Prompt = nameof(FromInventory), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Inventory? FromInventory { get; set; }
    
    
    
    [Display(Name = nameof(ToInventory), Prompt = nameof(ToInventory), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid ToInventoryId { get; set; }
    
    [Display(Name = nameof(ToInventory), Prompt = nameof(ToInventory), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Inventory? ToInventory { get; set; }
    
    
    
    [Display(Name = nameof(ProductInStorageRooms), Prompt = nameof(ProductInStorageRooms), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public ICollection<ProductInStorageRoom>? ProductInStorageRooms { get; set; }
}