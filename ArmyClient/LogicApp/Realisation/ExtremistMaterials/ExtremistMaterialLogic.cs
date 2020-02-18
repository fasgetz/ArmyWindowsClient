using ArmyClient.LogicApp.Interfaces.ExtremistMaterials;
using ArmyClient.Models.ModelExtremistMaterials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Realisation.ExtremistMaterials
{
    class ExtremistMaterialLogic : IExtremistMaterialLogic
    {
        ExmMaterialsDB db;

        public Task<List<Materials>> GetFoundedMaterials(DateTime startEntryDate, DateTime endEntreDate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Materials>> GetMaterialsAll(string name = null)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (db = new ExmMaterialsDB())
                    {
                        return db.Materials.ToList();
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
