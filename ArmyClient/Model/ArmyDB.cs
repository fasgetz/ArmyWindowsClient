namespace ArmyClient.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ArmyDB : DbContext
    {
        public ArmyDB()
            : base("name=ArmyDB")
        {
        }

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
            modelBuilder.Entity<Countries>()
                .HasMany(e => e.ForeignFriends)
                .WithOptional(e => e.Countries)
                .HasForeignKey(e => e.IdCountry);

            modelBuilder.Entity<Countries>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Countries)
                .HasForeignKey(e => e.IdCountryBirth);

            modelBuilder.Entity<Countries>()
                .HasMany(e => e.Users1)
                .WithOptional(e => e.Countries1)
                .HasForeignKey(e => e.IdCurrentCountryResidence);

            modelBuilder.Entity<CrimesType>()
                .HasMany(e => e.UserCrimesCategory)
                .WithRequired(e => e.CrimesType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SocialNetworkType>()
                .HasMany(e => e.SocialNetworkUser)
                .WithRequired(e => e.SocialNetworkType)
                .HasForeignKey(e => e.SocialNetworkId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SocialNetworkUser>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<SocialNetworkUser>()
                .HasMany(e => e.ForeignFriends)
                .WithRequired(e => e.SocialNetworkUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SocialNetworkUser>()
                .HasMany(e => e.UserCrimes)
                .WithOptional(e => e.SocialNetworkUser)
                .HasForeignKey(e => e.IdSocialNetworkUser);

            modelBuilder.Entity<SocialStatuses>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.SocialStatuses)
                .HasForeignKey(e => e.SocialStatusID);

            modelBuilder.Entity<SoldierUnit>()
                .Property(e => e.AbountInform)
                .IsUnicode(false);

            modelBuilder.Entity<SoldierUnit>()
                .HasMany(e => e.UserSoldierService)
                .WithOptional(e => e.SoldierUnit)
                .HasForeignKey(e => e.IdSoldierUnit);

            modelBuilder.Entity<UserCrimes>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<UserCrimes>()
                .HasMany(e => e.UserCrimesCategory)
                .WithRequired(e => e.UserCrimes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Characteristic)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.SocialNetworkUser)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserCrimes)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserSoldierService)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.IdUser);

            modelBuilder.Entity<UserSoldierService>()
                .Property(e => e.Data)
                .IsUnicode(false);
        }
    }
}
