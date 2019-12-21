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
            ArmyDBContext db = new ArmyDB();


            socialNetworksLogic = new SocialNetworksLogic(db);
            userLogic = new UserLogic(db);
            CountriesLogic = new CountriesLogic(db);
            SoldierUnitLogic = new SoldierUnitsLogic(db);
            SocStatusesLogic = new SocStatusesLogic(db);
        }
    }
}
