using App.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Action = System.Action;

namespace App.DAL.EF;

public class AppDbContext : IdentityDbContext
{
    public DbSet<ActionEntity> Actions { get; set; }
    public DbSet<ActionType> ActionTypes { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<ApprovalRequests> ApprovalRequests { get; set; }
    public DbSet<CurrentStock> CurrentStocks { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductInStorageRoom> ProductInStorageRooms { get; set; }
    public DbSet<Reason> Reasons { get; set; }
    public DbSet<StockAudit> StockAudits { get; set; }
    public DbSet<StockMovement> StockMovements { get; set; }
    public DbSet<StorageRoom> StorageRooms { get; set; }
    public DbSet<StorageRoomInInventory> StorageRoomInInventories { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    
    public DbSet<Role> Roles { get; set; }
    public DbSet<RoleClaim> RoleClaims { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserClaim> UserClaims { get; set; }
    public DbSet<UserLogin> UserLogins { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserToken> UserTokens { get; set; }
    
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}