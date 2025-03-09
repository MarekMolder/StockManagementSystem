using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class StockAudit : BaseEntity
{
    [Display(Name = nameof(CreatedAt), Prompt = nameof(CreatedAt), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public DateTime CreatedAt { get; set; }
    

    
    [Display(Name = nameof(StorageRoom), Prompt = nameof(StorageRoom), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid StorageRoomId { get; set; }
    
    [Display(Name = nameof(StorageRoom), Prompt = nameof(StorageRoom), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public StorageRoom? StorageRoom { get; set; }
    
    

    [Display(Name = nameof(User), Prompt = nameof(User), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public Guid UserId { get; set; }
    
    [Display(Name = nameof(User), Prompt = nameof(User), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public User? User { get; set; }
    
    
    
    [Display(Name = nameof(Actions), Prompt = nameof(Actions), ResourceType = typeof(App.Resources.Domain.CommonDomain))]
    public ICollection<ActionEntity>? Actions { get; set; }
}