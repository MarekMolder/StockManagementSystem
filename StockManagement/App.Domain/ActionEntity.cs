using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Base.Domain;

namespace App.Domain;

public class ActionEntity : BaseEntity
{
    [Display(Name = nameof(Quantity), Prompt = nameof(Quantity), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public decimal Quantity { get; set; }
    
    

    [Display(Name = nameof(CreatedAt), Prompt = nameof(CreatedAt), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime CreatedAt { get; set; }
    
    

    [MaxLength(50, ErrorMessageResourceType = typeof(Base.Resources.ErrorMessages), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(Status), Prompt = nameof(Status), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public String Status { get; set; } = default!;
    
    
    
    [Display(Name = nameof(ActionType), Prompt = nameof(ActionType), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid ActionTypeId { get; set; }
    
    [Display(Name = nameof(ActionType), Prompt = nameof(ActionType), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public ActionType? ActionType { get; set; }
    
    
    
    [Display(Name = nameof(Reason), Prompt = nameof(Reason), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid? ReasonId { get; set; }
    
    [Display(Name = nameof(Reason), Prompt = nameof(Reason), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Reason? Reason { get; set; }
    
    
    
    [Display(Name = nameof(Supplier), Prompt = nameof(Supplier), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid? SupplierId { get; set; }
    
    [Display(Name = nameof(Supplier), Prompt = nameof(Supplier), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Supplier? Supplier { get; set; }
    
    
    
    [Display(Name = nameof(User), Prompt = nameof(User), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid UserId { get; set; }
    
    [Display(Name = nameof(User), Prompt = nameof(User), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public User? User { get; set; }
    
    
    
    [Display(Name = nameof(Product), Prompt = nameof(Product), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid ProductId { get; set; }
    
    [Display(Name = nameof(Product), Prompt = nameof(Product), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Product? Product { get; set; }
    
    
    
    [Display(Name = nameof(StockAudit), Prompt = nameof(StockAudit), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid? StockAuditId { get; set; }
    
    [Display(Name = nameof(StockAudit), Prompt = nameof(StockAudit), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public StockAudit? StockAudit { get; set; }
}