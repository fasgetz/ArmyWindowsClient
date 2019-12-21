using ArmyClient.LogicApp.Interfaces;
using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Realisation
{
    class CountriesLogic : ICountriesLogic
    {
        private ArmyDBContext db;
        public CountriesLogic(ArmyDBContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Получить список стран
        /// </summary>
        /// <returns>Возвращает список стран</returns>
        public async Task<List<Countries>> GetCountries()
        {
            return await Task.Run(() =>
            {
                try
                {
                    return db.Countries.ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            });
        }
    }
}
