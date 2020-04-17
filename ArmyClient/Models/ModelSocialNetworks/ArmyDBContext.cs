namespace ArmyClient.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ArmyClient.Models.ModelSocialNetworks;

    public partial class ArmyDBContext : DbContext
    {
        public ArmyDBContext(string connectionstring)
            : base(connectionstring)
        {
            
        }

        public virtual DbSet<SocialNetworkAudio> SocialNetworkUserAudios { get; set; }
        public virtual DbSet<SocialNetworkGroup> SocialNetworkUserGroups { get; set; }
        public virtual DbSet<SocialNetworkSessions> Sessions { get; set; }
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




        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
