using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace App.Domain;

public class User : IdentityUser
{
    [InverseProperty("RequestedByUser")]
    public ICollection<ApprovalRequests>? ApprovalRequestsIn { get; set; }
    
    [InverseProperty("ApprovedByUser")]
    public ICollection<ApprovalRequests>? ApprovalRequestsOut { get; set; }
}