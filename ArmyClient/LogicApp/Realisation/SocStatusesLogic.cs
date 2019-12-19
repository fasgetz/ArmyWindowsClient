using ArmyClient.LogicApp.Interfaces;
using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Realisation
{
    class SocStatusesLogic : ISocStatusesLogic
    {
        public async Task<List<SocialStatuses>> GetSocialStatuses()
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (ArmyDB db = new ArmyDB())
                        return db.SocialStatuses.ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            });
        }

    }
}
