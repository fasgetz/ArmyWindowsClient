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

    }
}
