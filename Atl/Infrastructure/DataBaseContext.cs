using Atl.Domain;
using Atl.Domain.AppUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Atl.Infrastructure
{
    public class DataBaseContext : IdentityDbContext<AppUser>
    {
        public DataBaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Child> Children { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<FoodRestriction> FoodRestrictions { get; set; }
        public DbSet<HealthProblem> HealthProblems { get; set; }
        public DbSet<SpecialEd> SpecialEds { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<ChildMedicine> ChildMedicines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ChildMedicine>(x => x.HasKey(p => new { p.ChildId, p.MedicineId }));

            modelBuilder.Entity<ChildMedicine>()
                .HasOne(u => u.Child)
                .WithMany(u => u.ChildMedicines)
                .HasForeignKey(p => p.ChildId);

            modelBuilder.Entity<ChildMedicine>()
                .HasOne(u => u.Medicine)
                .WithMany(u => u.ChildMedicines)
                .HasForeignKey(p => p.MedicineId);
           
            //Mudar depois 

            modelBuilder.Entity<Child>()
               .HasMany(m => m.Allergies)
               .WithMany(c => c.Children)
               .UsingEntity(j => j.ToTable("ChildAllergy"));

            modelBuilder.Entity<Child>()
               .HasMany(m => m.FoodRestrictions)
               .WithMany(c => c.Children)
               .UsingEntity(j => j.ToTable("ChildFoodRestrictions"));

            modelBuilder.Entity<Child>()
               .HasMany(m => m.HealthProblems)
               .WithMany(c => c.Children)
               .UsingEntity(j => j.ToTable("ChildHealthProblem"));

            modelBuilder.Entity<Child>()
               .HasMany(m => m.Parents)
               .WithMany(c => c.Children)
               .UsingEntity(j => j.ToTable("ChildParents"));

            modelBuilder.Entity<Child>()
               .HasMany(m => m.SpecialEds)
               .WithMany(c => c.Children)
               .UsingEntity(j => j.ToTable("ChildSpecialEd"));



            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }

    }
}
