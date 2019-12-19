using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace ApiVK
{
    public class MyApiVK
    {
        #region Свойства

        private VkApi token;

        #endregion


        #region Методы аутентификации

        public bool AuthUser(string login, string password)
        {
            token = GetToken(login, password);


            // Возвращаем true, если авторизация успешна, иначе false
            return token != null ? true : false;
        }

        /// <summary>
        /// Метод, который получает токен для дальнейшей работы с апи
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>Возвращает токен</returns>
        public VkApi GetToken(string login, string password)
        {
            try
            {
                var api = new VkApi();

                api.Authorize(new ApiAuthParams
                {
                    ApplicationId = 123456,
                    Login = login,
                    Password = password,
                    Settings = Settings.All
                });

                return api;
            }
            catch (Exception)
            {
                return null;
            }

        }

        #endregion


    }
}
