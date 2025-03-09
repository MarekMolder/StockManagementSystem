using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Base.Domain;

namespace App.Domain;

public class ApprovalRequests : BaseEntity
{
    [MaxLength(50)]
    [Display(Name = nameof(Status), Prompt = nameof(Status), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public string Status { get; set; } = default!;
    
    
    
    [Display(Name = nameof(CreatedAt), Prompt = nameof(CreatedAt), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime CreatedAt { get; set; }
    
    
    
    [Display(Name = nameof(ApprovedAt), Prompt = nameof(ApprovedAt), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime? ApprovedAt { get; set; }
    
    
    
    [Display(Name = nameof(Action), Prompt = nameof(Action), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid ActionId { get; set; }
    
    [Display(Name = nameof(Action), Prompt = nameof(Action), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public ActionEntity? Action { get; set; }
    
    
    
    [Display(Name = nameof(RequestedByUser), Prompt = nameof(RequestedByUser), ResourceType = typeof(App.Resources.Domain.ApprovalRequests))]
    public Guid RequestedByUserId { get; set; }
    
    [Display(Name = nameof(RequestedByUser), Prompt = nameof(RequestedByUser), ResourceType = typeof(App.Resources.Domain.ApprovalRequests))]
    public User? RequestedByUser { get; set; }
    
    
    
    [Display(Name = nameof(ApprovedByUser), Prompt = nameof(ApprovedByUser), ResourceType = typeof(App.Resources.Domain.ApprovalRequests))]
    public Guid? ApprovedByUserId { get; set; }
    
    [Display(Name = nameof(ApprovedByUser), Prompt = nameof(ApprovedByUser), ResourceType = typeof(App.Resources.Domain.ApprovalRequests))]
    public User? ApprovedByUser { get; set; }
}