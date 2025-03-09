using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class Product : BaseEntity
{
    [MaxLength(20)]
    [Display(Name = nameof(Unit), Prompt = nameof(Unit), ResourceType = typeof(App.Resources.Domain.Product))]
    public string Unit { get; set; } = default!;
    
    

    [MaxLength(255)]
    [Display(Name = nameof(Code), Prompt = nameof(Code), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public string Code { get; set; } = default!;
    
    
    
    [MaxLength(128)]
    [Display(Name = nameof(Name), Prompt = nameof(Name), ResourceType = typeof(App.Resources.Domain.Product))]
    public string Name { get; set; } = default!;
    
    
    
    [Display(Name = nameof(Price), Prompt = nameof(Price), ResourceType = typeof(App.Resources.Domain.Product))]
    public decimal Price { get; set; }
    
    
    
    [Display(Name = nameof(Quantity), Prompt = nameof(Quantity), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public decimal Quantity { get; set; }
    
    
    
    [Display(Name = nameof(CreatedAt), Prompt = nameof(CreatedAt), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime CreatedAt { get; set; }
    
    
    
    [Display(Name = nameof(ProductCategory), Prompt = nameof(ProductCategory), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid ProductCategoryId { get; set; }
    
    [Display(Name = nameof(ProductCategory), Prompt = nameof(ProductCategory), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public ProductCategory? ProductCategory { get; set; }
    
    
    
    [Display(Name = nameof(Actions), Prompt = nameof(Actions), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public ICollection<ActionEntity>? Actions { get; set; }
    
    
    
    [Display(Name = nameof(ProductInStorageRooms), Prompt = nameof(ProductInStorageRooms), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public ICollection<ProductInStorageRoom>? ProductInStorageRooms { get; set; }
    
    
    
    [Display(Name = nameof(CurrentStocks), Prompt = nameof(CurrentStocks), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public ICollection<CurrentStock>? CurrentStocks { get; set; }
}