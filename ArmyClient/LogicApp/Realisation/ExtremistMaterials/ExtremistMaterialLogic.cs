using ArmyClient.LogicApp.Interfaces.ExtremistMaterials;
using ArmyClient.ModelExtremistMaterials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Realisation.ExtremistMaterials
{
    class ExtremistMaterialLogic : IExtremistMaterialLogic
    {
        ExtremistMaterialsDB db;

        public async Task<List<Materials>> GetMaterialsAll(string name = null)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (db = new ExtremistMaterialsDB())
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
