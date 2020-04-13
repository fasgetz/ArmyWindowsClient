using ArmyClient.LogicApp.Interfaces;
using ArmyClient.LogicApp.Interfaces.ExtremistMaterials;
using ArmyClient.LogicApp.Realisation.ExtremistMaterials;
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
        internal ICitiesLogic citiesLogic;
        internal IUsersLogic userLogic;
        internal ISocialNetworksLogic socialNetworksLogic;
        internal ISoldierUnitsLogic SoldierUnitLogic;
        internal ICountriesLogic CountriesLogic;
        internal ISocStatusesLogic SocStatusesLogic;
        internal ICrimesLogic CrimesLogic;
        internal IForeignFriendsLogic ForeignFriendsLogic;
        internal IExtremistMaterialLogic ExtremistMaterialLogic;
        internal IGroupsLogic GroupLogic;

        internal LogicApp()
        {
            ArmyDBContext db = new ArmyDB();

            // Провайдер базы данных
            var provider = new LogicProviderDB(LogicProviderDB.databases.mssql);


            socialNetworksLogic = new SocialNetworksLogic(provider);
            userLogic = new UserLogic(provider);
            CountriesLogic = new CountriesLogic(provider);
            SoldierUnitLogic = new SoldierUnitsLogic(provider);
            SocStatusesLogic = new SocStatusesLogic(provider);
            citiesLogic = new CitiesLogic(provider);
            CrimesLogic = new CrimesLogic(provider);
            ForeignFriendsLogic = new ForeignFriendsLogic(provider);
            ExtremistMaterialLogic = new ExtremistMaterialLogic();
            GroupLogic = new GroupsLogic(provider);
        }
    }
}
