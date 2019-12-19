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

        /// <summary>
        /// Получить список В/Ч по стране
        /// </summary>
        /// <param name="IdCountry">Айди страны</param>
        /// <returns>Возвращает список В/Ч</returns>
        public async Task<List<SoldierUnit>> GetSoldierUnitsAsync(byte IdCountry)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (ArmyDB db = new ArmyDB())
                    {
                        if (IdCountry == 0)
                            return db.SoldierUnit.ToList();

                        return db.SoldierUnit.Where(i => i.IdCountry == IdCountry).ToList(); // Возвращаем по айди страны
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
