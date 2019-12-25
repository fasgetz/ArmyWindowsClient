using ArmyClient.LogicApp.Interfaces;
using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Realisation
{
    class CitiesLogic : ICitiesLogic
    {
        LogicProviderDB provider;
        ArmyDBContext db;

        public CitiesLogic(LogicProviderDB provider)
        {
            this.provider = provider;
        }


        /// <summary>
        /// Получить список городов страны
        /// </summary>
        /// <returns>Возвращает список городов страны</returns>
        public async Task<List<City>> GetCities(byte idCountry)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (db = provider.GetProvider())
                    {
                        return db.City.Where(i => i.CountryId == idCountry).ToList();
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
