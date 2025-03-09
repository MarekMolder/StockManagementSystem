using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class ActionType : BaseEntity
{
    [MaxLength(255)]
    [Display(Name = nameof(Name), Prompt = nameof(Name), ResourceType = typeof(App.Resources.Domain.ActionType))]
    public string Name { get; set; } = default!;
    
    
    
    [Display(Name = nameof(CreatedAt), Prompt = nameof(CreatedAt), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime CreatedAt { get; set; }
    
    
    
    [Display(Name = nameof(EndedAt), Prompt = nameof(EndedAt), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime? EndedAt { get; set; }
    
    
    
    [Display(Name = nameof(Actions), Prompt = nameof(Actions), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public ICollection<ActionEntity>? Actions { get; set; }
}