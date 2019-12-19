using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Interfaces
{
    internal interface ISocialNetworksLogic
    {
        #region Синхронные версии методов

        //List<SocialNetworkType> LoadSocialNetworkTypes();

        #endregion

        #region Асинхронные версии методов

        Task<List<SocialNetworkType>> LoadSocialNetworkTypesAsync();

        #endregion
    }
}
