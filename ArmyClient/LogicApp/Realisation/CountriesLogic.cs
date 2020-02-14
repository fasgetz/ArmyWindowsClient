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
        LogicProviderDB provider;
        ArmyDBContext db;

        public CountriesLogic(LogicProviderDB provider)
        {
            this.provider = provider;                        
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
                    using (db = provider.GetProvider())
                    {
                        return db.Countries.Take(5).ToList();
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
