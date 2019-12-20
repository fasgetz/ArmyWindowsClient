using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApiVK;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;

namespace ConsoleTest
{
    class Program
    {

        /// <summary>
        /// Искать друзей, у которых есть воинские части
        /// </summary>
        /// <param name="UserID">айди пользователя</param>
        static async void SearchUnitSoldier(VkApi token, int UserID)
        {
            await Task.Run(() =>
            {
                try
                {
                    friends = token.Friends.Get(new VkNet.Model.RequestParams.FriendsGetParams()
                    {
                        UserId = UserID,
                        Count = 10000,
                        Fields = ProfileFields.Military
                    }).ToArray();


                    for (int i = 0; i <= (friends.Length / 10) - 1; i++)
                    {
                        // создаем новый поток
                        Thread myThread = new Thread(new ParameterizedThreadStart(Count));

                        myThread.Start(i);
                    }


                    //// Выбрать всех военнослужащих
                    //foreach (var item in friends)
                    //{
                    //    // Инфа о юзере
                    //    var user = token.Users.Get(new long[]
                    //    {
                    //        item.Id
                    //    }, VkNet.Enums.Filters.ProfileFields.All).FirstOrDefault();

                    //    // Если такого юзера нашли, то выведи в консоль и запиши его в файлик
                    //    if (user.Military != null)
                    //    {
                    //        //using (StreamWriter w = new StreamWriter($"Друзья у которых ВЧ пользователя {UserID} ({DateTime.Now}).txt", false, Encoding.GetEncoding(1251)))
                    //        //{
                    //        //    w.Write("Строка1");
                    //        //}



                    //        // запись в файл
                    //        using (FileStream fstream = new FileStream($"Друзья у которых ВЧ пользователя {UserID}.txt", FileMode.Append))
                    //        {
                    //            // преобразуем строку в байты
                    //            byte[] array = System.Text.Encoding.Default.GetBytes($"{user.Id} {user.FirstName} {user.LastName} {user.Country?.Title} {user.City?.Title} {user.Military?.Unit}");
                    //            // запись массива байтов в файл
                    //            fstream.Write(array, 0, array.Length);
                    //        }

                    //        Console.WriteLine($"{user.Id} {user.FirstName} {user.LastName} {user.Country?.Title} {user.City?.Title} {user.Military?.Unit}");
                    //    }


                    //};
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("end");
            });
        }

        static object locker = new object();
        static VkNet.Model.User[] friends;
        static VkNet.VkApi token;

        // Для проверки
        static void Count(object i)
        {
            for (int s = (int)i; s < ((int)i + 1) * 10; s++)
            {

                try
                {
                    // Инфа о юзере
                    var user = token.Users.Get(new long[]
                    {
                        friends[s].Id
                    }, VkNet.Enums.Filters.ProfileFields.All).FirstOrDefault();

                    Console.WriteLine($"{s}) {friends[s].Id} {friends[s].FirstName} {friends[s].LastName} {friends[s].Country?.Title} {friends[s].City?.Title} {friends[s].Military?.Unit}");
                    Thread.Sleep(500);
                }
                catch (Exception)
                {
                    Console.WriteLine($"{s} is bad Request!!!");
                }
                // Инфа о юзере
                //var user = token.Users.Get(new long[]
                //{
                //    friends[s].Id
                //}, VkNet.Enums.Filters.ProfileFields.All).FirstOrDefault();

                //Console.WriteLine($"{friends[s].Id} {friends[s].FirstName} {friends[s].LastName} {friends[s].Country?.Title} {friends[s].City?.Title} {friends[s].Military?.Unit}");
                //Thread.Sleep(500);
                //    // Если такого юзера нашли, то выведи в консоль и запиши его в файлик
                //    if (user.Military != null)
                //    {
                //        //using (StreamWriter w = new StreamWriter($"Друзья у которых ВЧ пользователя {UserID} ({DateTime.Now}).txt", false, Encoding.GetEncoding(1251)))
                //        //{
                //        //    w.Write("Строка1");
                //        //}



                //        // запись в файл
                //        using (FileStream fstream = new FileStream($"Друзья у которых ВЧ пользователя {UserID}.txt", FileMode.Append))
                //        {
                //            // преобразуем строку в байты
                //            byte[] array = System.Text.Encoding.Default.GetBytes($"{user.Id} {user.FirstName} {user.LastName} {user.Country?.Title} {user.City?.Title} {user.Military?.Unit}");
                //            // запись массива байтов в файл
                //            fstream.Write(array, 0, array.Length);
                //        }

                //        Console.WriteLine($"{user.Id} {user.FirstName} {user.LastName} {user.Country?.Title} {user.City?.Title} {user.Military?.Unit}");
                //    }
            }

        }

        /// <summary>
        /// Искать иностранных друзей у пользователя
        /// </summary>
        /// <param name="UserID">айди пользователя</param>
        static async void SearchForeignFriends(VkApi token, int UserID)
        {
            await Task.Run(() =>
            {

                friends = token.Friends.Get(new VkNet.Model.RequestParams.FriendsGetParams()
                {
                    UserId = UserID,
                    Count = 10000,
                    Fields = ProfileFields.All
                }).ToArray();


                for (int i = 0; i <= (friends.Length / 10) - 1; i++)
                {

                    // создаем новый поток
                    Task task = new Task(() => 
                    {
                        for (int s = i; s < (s + 1) * 10; s++)
                        {
                            try
                            {
                                // Инфа о юзере
                                var user = token.Users.Get(new long[]
                                {
                                friends[s].Id
                                }, VkNet.Enums.Filters.ProfileFields.All).FirstOrDefault();

                                Console.WriteLine($"{s}) {friends[s].Id} {friends[s].FirstName} {friends[s].LastName} {friends[s].Country?.Title} {friends[s].City?.Title} {friends[s].Military?.Unit}");
                                Thread.Sleep(500);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine($"{s} is bad Request!!!");
                            }
                        }
                    });

                    task.Start();
                }


                //// Выбрать всех не из России
                //foreach (var item in friends.Where(i => i.Country != null && i.Country?.Id != 1))
                //{
                //    Console.WriteLine($"{item.Id} {item.FirstName} {item.LastName} {item.Country?.Title}");
                //};

                Console.WriteLine("end");
            });
        }

        /// <summary>
        /// Искать иностранных друзей у пользователя
        /// </summary>
        /// <param name="UserID">айди пользователя</param>
        static async void SearchForeignFriendsOLD(VkApi token, int UserID)
        {
            await Task.Run(() =>
            {

                friends = token.Friends.Get(new VkNet.Model.RequestParams.FriendsGetParams()
                {
                    UserId = UserID,
                    Count = 10000,
                    Fields = ProfileFields.All
                }).ToArray();


                // Выбрать всех не из России
                foreach (var item in friends.Where(i => i.Country != null && i.Country?.Id != 1))
                {
                    Console.WriteLine($"{item.Id} {item.FirstName} {item.LastName} {item.Country?.Title}");
                };

                Console.WriteLine("end");
            });
        }

        /// <summary>
        /// Искать по своей выборке
        /// </summary>
        /// <param name="UserID">айди пользователя</param>
        static async void Search(VkApi token, int UserID)
        {
            await Task.Run(() =>
            {
                var friends = token.Friends.Get(new VkNet.Model.RequestParams.FriendsGetParams()
                {
                    UserId = UserID,
                    Count = 10000,
                    Fields = ProfileFields.All
                });


                // Выбрать всех по критериям
                foreach (var item in friends.Where(i => i.BirthDate == "30.10" || i.BirthDate == "23.8.1998"))
                {


                    Console.WriteLine($"{item.Id} {item.FirstName} {item.LastName} {item.Country?.Title} {item.BirthDate}");
                };

                Console.WriteLine("end");
            });
        }





        static void Main()
        {
            Console.WriteLine("Старт");

            // Токен
            MyApiVK api = new MyApiVK();
            token = api.GetToken("89114876557", "Simplepass19");

            SearchForeignFriendsOLD(token, 298394722);



            Console.WriteLine("end!");
            Console.ReadKey();

        }



    }
}
