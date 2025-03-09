using System.ComponentModel.DataAnnotations;

namespace Base.Domain;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    
    [StringLength(3000)]
    public string? Comment { get; set; } = default!;
}