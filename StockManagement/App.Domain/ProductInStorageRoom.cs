using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class ProductInStorageRoom : BaseEntity
{
    [MaxLength(128)]
    [Display(Name = nameof(Code), Prompt = nameof(Code), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public string Code { get; set; } = default!;
    
    
    
    [Display(Name = nameof(Quantity), Prompt = nameof(Quantity), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public decimal Quantity { get; set; }
    
    
    
    [Display(Name = nameof(ManufacturingDate), Prompt = nameof(ManufacturingDate), ResourceType = typeof(App.Resources.Domain.ProductInStorageRoom))]
    public DateTime ManufacturingDate { get; set; }
    
    
    
    [Display(Name = nameof(ExpiryDate), Prompt = nameof(ExpiryDate), ResourceType = typeof(App.Resources.Domain.ProductInStorageRoom))]
    public DateTime ExpiryDate { get; set; }
    
    
    
    [Display(Name = nameof(CreatedAt), Prompt = nameof(CreatedAt), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime CreatedAt { get; set; }
    
    
    
    [Display(Name = nameof(Action), Prompt = nameof(Action), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid ActionId { get; set; }
    
    [Display(Name = nameof(Action), Prompt = nameof(Action), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public ActionEntity? Action { get; set; }
    
    
    
    [Display(Name = nameof(Product), Prompt = nameof(Product), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid ProductId { get; set; }
    
    [Display(Name = nameof(Product), Prompt = nameof(Product), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Product? Product { get; set; }
    
    
    
    [Display(Name = nameof(Supplier), Prompt = nameof(Supplier), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid SupplierId { get; set; }
    
    [Display(Name = nameof(Supplier), Prompt = nameof(Supplier), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Supplier? Supplier { get; set; }
    
    
    
    [Display(Name = nameof(StockMovement), Prompt = nameof(StockMovement), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid? StockMovementId { get; set; }
    
    [Display(Name = nameof(StockMovement), Prompt = nameof(StockMovement), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public StockMovement? StockMovement { get; set; }
    
    
    
    [Display(Name = nameof(StorageRoom), Prompt = nameof(StorageRoom), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid StorageRoomId { get; set; }
    
    [Display(Name = nameof(StorageRoom), Prompt = nameof(StorageRoom), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public StorageRoom? StorageRoom { get; set; }
}