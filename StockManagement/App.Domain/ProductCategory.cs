using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class ProductCategory : BaseEntity
{
    [MaxLength(128)]
    [Display(Name = nameof(Name), Prompt = nameof(Name), ResourceType = typeof(App.Resources.Domain.ProductCategory))]
    public string Name { get; set; } = default!;
    
    
    
    [Display(Name = nameof(CreatedAt), Prompt = nameof(CreatedAt), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime CreatedAt { get; set; }
    
    
    
    [Display(Name = nameof(EndedAt), Prompt = nameof(EndedAt), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime? EndedAt { get; set; }
    
    
    
    [Display(Name = nameof(Products), Prompt = nameof(Products), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public ICollection<Product>? Products { get; set; }
}