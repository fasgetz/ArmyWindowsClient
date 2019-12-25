using ArmyClient.LogicApp.Interfaces;
using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Realisation
{
    internal class SoldierUnitsLogic : ISoldierUnitsLogic
    {
        LogicProviderDB provider;
        ArmyDBContext db;

        public SoldierUnitsLogic(LogicProviderDB provider)
        {
            this.provider = provider;
        }

        /// <summary>
        /// Получить список В/Ч по стране
        /// </summary>
        /// <param name="IdCountry">Айди города</param>
        /// <returns>Возвращает список В/Ч</returns>
        public async Task<List<SoldierUnit>> GetSoldierUnitsAsync(int IdCountry)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (db = provider.GetProvider())
                    {
                        if (IdCountry == 0)
                            return db.SoldierUnit.ToList();

                        return db.SoldierUnit.Where(i => i.IdCity == IdCountry).ToList(); // Возвращаем по айди города
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
