using ArmyClient.LogicApp.Interfaces;
using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Realisation
{
    internal class LogicApp
    {
        internal IUsersLogic userLogic;
        internal ISocialNetworksLogic socialNetworksLogic;
        internal ISoldierUnitsLogic SoldierUnitLogic;
        internal ICountriesLogic CountriesLogic;
        internal ISocStatusesLogic SocStatusesLogic;

        internal LogicApp()
        {
            socialNetworksLogic = new SocialNetworksLogic();
            userLogic = new UserLogic();
            CountriesLogic = new CountriesLogic();
            SoldierUnitLogic = new SoldierUnitsLogic();
            SocStatusesLogic = new SocStatusesLogic();
        }
    }
}
