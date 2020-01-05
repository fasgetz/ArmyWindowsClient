using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.Model
{

    /// <summary>
    /// PostgreSQL контекст
    /// </summary>
    public partial class ArmyDB_PG : ArmyDBContext
    {
        public ArmyDB_PG()
            : base("name=ArmyDB_PG")
        {
        }


    }
}
