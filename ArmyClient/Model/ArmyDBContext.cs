namespace ArmyClient.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ArmyDBContext : DbContext
    {
        public ArmyDBContext(string connectionstring)
            : base(connectionstring)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<CrimesType> CrimesType { get; set; }
        public virtual DbSet<ForeignFriends> ForeignFriends { get; set; }
        public virtual DbSet<SocialNetworkType> SocialNetworkType { get; set; }
        public virtual DbSet<SocialNetworkUser> SocialNetworkUser { get; set; }
        public virtual DbSet<SocialStatuses> SocialStatuses { get; set; }
        public virtual DbSet<SoldierUnit> SoldierUnit { get; set; }
        public virtual DbSet<UserCrimes> UserCrimes { get; set; }
        public virtual DbSet<UserCrimesCategory> UserCrimesCategory { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserSoldierService> UserSoldierService { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.City)
                .HasForeignKey(e => e.CityBirth_Id);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Users1)
                .WithOptional(e => e.City1)
                .HasForeignKey(e => e.CurrentCityResience_Id);

            modelBuilder.Entity<City>()
                .HasMany(e => e.ForeignFriends)
                .WithOptional(e => e.City)
                .HasForeignKey(e => e.IdCity);

            modelBuilder.Entity<City>()
                .HasMany(e => e.SoldierUnit)
                .WithOptional(e => e.City)
                .HasForeignKey(e => e.IdCity);

            modelBuilder.Entity<Countries>()
                .HasMany(e => e.City)
                .WithOptional(e => e.Countries)
                .HasForeignKey(e => e.CountryId);

            modelBuilder.Entity<SocialNetworkType>()
                .HasMany(e => e.SocialNetworkUser)
                .WithRequired(e => e.SocialNetworkType)
                .HasForeignKey(e => e.SocialNetworkId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SocialStatuses>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.SocialStatuses)
                .HasForeignKey(e => e.SocialStatusID);

            modelBuilder.Entity<SoldierUnit>()
                .HasMany(e => e.UserSoldierService)
                .WithOptional(e => e.SoldierUnit)
                .HasForeignKey(e => e.IdSoldierUnit);

            modelBuilder.Entity<UserCrimes>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Characteristic)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.SocialNetworkUser)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserCrimes)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserSoldierService)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.IdUser);
        }
    }
}
