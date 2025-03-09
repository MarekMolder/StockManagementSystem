using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class Reason : BaseEntity
{
    [MaxLength(256)]
    [Display(Name = nameof(Description), Prompt = nameof(Description), ResourceType = typeof(App.Resources.Domain.Reason))]
    public string Description { get; set; } = default!;
    
    
    
    [Display(Name = nameof(CreatedAt), Prompt = nameof(CreatedAt), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime CreatedAt { get; set; }
    
    
    
    [Display(Name = nameof(EndedAt), Prompt = nameof(EndedAt), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime? EndedAt { get; set; }
    
    
    
    [Display(Name = nameof(Actions), Prompt = nameof(Actions), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public ICollection<ActionEntity>? Actions { get; set; }
}