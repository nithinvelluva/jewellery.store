using Microsoft.EntityFrameworkCore;
using Jewellery.Store.DAL.Entity;

namespace Jewellery.Store.DAL.DBContext
{
    public class MainDbContext : DbContext
    {
        public DbSet<UserTypeEntity> UserTypes { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<DiscountEntity> Discounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=dolittle.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<OwnerEntity>(entity =>
            //{
            //  entity.HasKey(e => e.id);
            //  entity.Property(e => e.first_name);
            //  entity.Property(e => e.last_name);
            //});

            //modelBuilder.Entity<PetEntity>(entity =>
            //{
            //  entity.HasKey(e => e.id);
            //  entity.Property(e => e.owner_id).IsRequired();
            //  entity.Property(e => e.type).IsRequired();
            //  entity.Property(e => e.name).IsRequired();
            //  entity.Property(e => e.age).IsRequired();
            //  entity.has(d => d.Owner).WithMany(o => o.);

            //});

            //modelBuilder.Entity<AppointmentEntity>(entity =>
            //{
            //  entity.HasKey(e => e.id);
            //  entity.Property(e => e.pet_id).IsRequired();
            //  entity.Property(e => e.slot_from).IsRequired();
            //  entity.Property(e => e.slot_to).IsRequired(); 
            //  entity.HasOne(d => d.Pet);

            //});
        }
    }
}
