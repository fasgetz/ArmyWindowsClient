using ArmyClient.LogicApp.Interfaces;
using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Realisation
{
    class SocialNetworksLogic : ISocialNetworksLogic
    {
        private ArmyDBContext db;

        public SocialNetworksLogic(ArmyDBContext db)
        {
            this.db = db;
        }


        public async Task<List<SocialNetworkType>> LoadSocialNetworkTypesAsync()
        {
            return await Task.Run(() =>
            {
                try
                {
                    return db.SocialNetworkType.ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            });

        }


    }
}
