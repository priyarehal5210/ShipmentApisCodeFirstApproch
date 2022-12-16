using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShipingApisWithCodeFirstApprochEF6.Interfaces;
using ShipingApisWithCodeFirstApprochEF6.Model;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    public DbSet<ShipingApisWithCodeFirstApprochEF6.Model.ShipFromAddress> ShipFromAddress { get; set; }
    public DbSet<ShipingApisWithCodeFirstApprochEF6.Model.ShipToAddress> shipToAddresses { get; set; }
    public DbSet<ShipingApisWithCodeFirstApprochEF6.Model.Client> clients { get; set; }
    public DbSet<ShipingApisWithCodeFirstApprochEF6.Model.Shipment> shipments { get; set; }
    public DbSet<ShipingApisWithCodeFirstApprochEF6.Model.ShipmentPackage> shipmentPackages { get; set; }
    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();

        var markedAsDeleted = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted);

        foreach (var item in markedAsDeleted)
        {
            if (item.Entity is ISoftDelete entity)
            {
                // Set the entity to unchanged (if we mark the whole entity as Modified, every field gets sent to Db as an update)
                item.State = EntityState.Unchanged;
                // Only update the IsDeleted flag - only this will get sent to the Db
                // entity.IssDeleted = false;
            }
        }
        return base.SaveChanges();
    }
}
