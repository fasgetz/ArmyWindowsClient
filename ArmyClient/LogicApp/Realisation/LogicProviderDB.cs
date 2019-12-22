using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Realisation
{
    /// <summary>
    /// Логика определения конкретного провайдера БД
    /// </summary>
    internal class LogicProviderDB
    {

        public LogicProviderDB(databases db)
        {
            provider = db;
        }

        databases provider;


        /// <summary>
        /// Метод получения проводника базы данных
        /// </summary>
        /// <returns></returns>
        internal ArmyDBContext GetProvider()
        {
            switch (provider)
            {
                case databases.mssql:
                    return new ArmyDB();
                case databases.postgresql:
                    return new ArmyDB_PG();
                default:
                    return null;
            }
        }

        public enum databases
        {
            postgresql,
            mssql
        }
    }
}
