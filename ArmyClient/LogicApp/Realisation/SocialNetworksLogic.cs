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
        LogicProviderDB provider;
        ArmyDBContext db;

        public SocialNetworksLogic(LogicProviderDB provider)
        {
            this.provider = provider;
        }


        public async Task<List<SocialNetworkType>> LoadSocialNetworkTypesAsync()
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (db = db = provider.GetProvider())
                    {
                        return db.SocialNetworkType.ToList();
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
