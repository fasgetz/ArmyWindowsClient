using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace ArmyClient.LogicApp.VK
{
    public static class VkLogic
    {

        public static ArmyVkAPI.MyApiVK MyApi { get; private set; }


        /// <summary>
        /// Метод для авторизации
        /// </summary>
        /// <returns></returns>
        public static bool Auth(string login, string password)
        {
            try
            {

                MyApi = new ArmyVkAPI.MyApiVK();
                bool AuthSuccessful = MyApi.Authorization(login, password);

                return MyApi.IsAuth();                
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static bool IsAuthorized()
        {
            return MyApi.IsAuth();
        }
    }
}
