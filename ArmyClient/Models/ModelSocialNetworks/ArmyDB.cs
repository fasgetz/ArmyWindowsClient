namespace ArmyClient.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ArmyDB : ArmyDBContext
    {
        public ArmyDB()
            : base("name=ArmyDB")
        {
        }

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

            modelBuilder.Entity<Countries>()
                .HasMany(e => e.UsersBirthInCountry)
                .WithOptional(e => e.CountryBirth)
                .HasForeignKey(e => e.CountryBirth_Id);

            modelBuilder.Entity<Countries>()
                .HasMany(e => e.UsersResidence)
                .WithOptional(e => e.CountryResidence)
                .HasForeignKey(e => e.CountryResidence_Id);

            // Иностранные друзья пользователя
            modelBuilder.Entity<Countries>()
                .HasMany(e => e.ForeignFriends)
                .WithOptional(e => e.Country)
                .HasForeignKey(e => e.CountryId);

            modelBuilder.Entity<SocialNetworkType>()
                .HasMany(e => e.SocialNetworkUser)
                .WithRequired(e => e.SocialNetworkType)
                .HasForeignKey(e => e.SocialNetworkId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SocialNetworkUser>()
                .HasMany(e => e.UserCrimes)
                .WithOptional(e => e.SocialNetworkUser)
                .HasForeignKey(e => e.IdSocialNetworkUser)
                .WillCascadeOnDelete();

            // тут
            modelBuilder.Entity<SocialNetworkUser>()
                .HasMany(e => e.SocialNetworkUserSessions)
                .WithRequired(e => e.SocialNetworkUser)
                .HasForeignKey(e => e.IdSocialNetworkUser)
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
                .HasMany(e => e.UserSoldierService)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.IdUser);
        }
    }
}
