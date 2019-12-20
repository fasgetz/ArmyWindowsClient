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
        public async Task<List<SocialNetworkType>> LoadSocialNetworkTypesAsync()
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (ArmyDB db = new ArmyDB())
                        return db.SocialNetworkType.ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            });

        }

        public SocialNetworksLogic()
        {

        }

    }
}
