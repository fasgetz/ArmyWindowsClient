using ArmyClient.LogicApp.Interfaces;
using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Realisation
{
    class CrimesLogic : ICrimesLogic
    {

        LogicProviderDB provider;
        ArmyDBContext db;

        public CrimesLogic(LogicProviderDB provider)
        {
            this.provider = provider;
        }



        /// <summary>
        /// Загрузка типов преступлений
        /// </summary>
        /// <returns>Возвращаем список типов преступлений</returns>
        public async Task<List<CrimesType>> LoadCrimesCategory()
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (db = provider.GetProvider())
                    {
                        return db.CrimesType.ToList();
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            });
        }
    }
}
