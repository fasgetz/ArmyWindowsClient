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
        /// Получить список В/Ч по городу
        /// </summary>
        /// <param name="IdCity">Айди города</param>
        /// <returns>Возвращает список В/Ч</returns>
        public async Task<List<SoldierUnit>> GetSoldierUnitsCityAsync(int IdCity)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (db = provider.GetProvider())
                    {
                        if (IdCity == 0)
                            return db.SoldierUnit.ToList();

                        return db.SoldierUnit.Where(i => i.IdCity == IdCity).ToList(); // Возвращаем по айди города
                    }
                        


                }
                catch (Exception)
                {
                    return null;
                }
            });
        }


        /// <summary>
        /// Получить список В/Ч по стране
        /// </summary>
        /// <param name="IdCountry">Айди страны</param>
        /// <returns>Возвращает список В/Ч</returns>
        public async Task<List<SoldierUnit>> GetSoldierUnitsCountryAsync(int IdCountry)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (db = provider.GetProvider())
                    {
                        if (IdCountry == 0)
                            return db.SoldierUnit.ToList();

                        return db.SoldierUnit.Where(i => i.City.CountryId == IdCountry).ToList(); // Возвращаем по айди города
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
