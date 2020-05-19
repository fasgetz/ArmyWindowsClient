using System;
using Word = Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing.Imaging;
using ArmyClient.Model;

namespace ArmyClient.LogicApp.WordLogic
{
    class WordLogic
    {
        public static void CreateUserReport(Model.Users user)
        {
            // Создаём объект документа
            Word.Document doc = null;

            // Создаём объект приложения
            Word.Application app = new Word.Application();

           
            try
            {
                string FileSource = @"C:\\Users\Andrew\Desktop\Шаблоны WORD\";

                // Путь до шаблона документа
                string source = FileSource + "UserReport.docx";

                // !!!!!!!!!!!!!!!!!!!!! Остановился на том, чтобы сделать отдельный каталог (папку) каждому юзеру


                FileSource += $"{user.Family} {user.Name}";

                DirectoryInfo dirInfo = new DirectoryInfo(FileSource);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }





                // Открываем
                doc = app.Documents.Open(source);
                doc.Activate();

                // Добавляем информацию

                // добавляем картинку
                {
                    // Сохраняем картинку
                    // Первым делом необходимо сохранить картинку из byte[] в .png
                    using (System.Drawing.Image image = System.Drawing.Image.FromStream(new MemoryStream(user.Photo)))
                    {
                        image.Save(@"D:\user.png", ImageFormat.Png);  // Or Png
                    }

                    object f = false;
                    object t = true;
                    object range = Type.Missing;

                    doc.Bookmarks["UserPhoto"].Range.InlineShapes.AddPicture(@"D:\user.png", ref f, ref t, ref range);
                }

                // Добавляем характеристику
                string characteristic = $"{user.Family} {user.Name}, {user.DateBirth.Value.Day}.{user.DateBirth.Value.Month}.{user.DateBirth.Value.Year}";

                // Проверяем указан ли город
                if (user.City1 != null)
                {
                    characteristic += $", г. {user.City1.Name}.";
                }
                else
                    characteristic += ".";

                if (user.GetFirstUS != null)
                    characteristic += $" Проходит службу в {user.GetFirstUS}.";





                // Общий список друзей
                List<ForeignFriends> foreignFriends = new List<ForeignFriends>();
                // Список преступлений
                List<UserCrimes> userCrimes = new List<UserCrimes>();

                // Собираем друзей иностранцев и фотографии добавленные к соцсетям в бд
                using (ArmyDBContext db = new ArmyDB())
                {
                    // Добавляем в каких соц. сетях зарегистрирован



                    if (user.SocialNetworkUser.Count() != 0)
                    {
                        foreach (var item in user.SocialNetworkUser)
                        {
                            characteristic += $" Зарегистрирован(а) в социальной сети {item.SocialNetworkType.Name}, адрес {item.WebAddress};";


                            var crimes = db.UserCrimes.Where(i => (int)i.IdSocialNetworkUser == item.Id);

                            //  Если есть нарушения у социальной сети, то необходимо записать
                            if (crimes != null && crimes.Count() != 0)
                            {
                                userCrimes.AddRange(crimes);
                            }
                        }
                    }

                    // Теперь, если есть преступления, то необходимо их добавить и описать
                    if (userCrimes.Count != 0)
                        characteristic += $" Есть {userCrimes.Count} военных фото (см. Приложение военных фотографий).";
                    else
                        characteristic += $" Военных фотографий в социальных сетях не имеет.";


                    foreach (var socialnetwork in user.SocialNetworkUser)
                    {
                        // Получаем друзей
                        var foreignfriends = db.ForeignFriends.Include("Country").Where(i => i.SocialNetworkUserID == socialnetwork.Id).ToList();

                        if (foreignfriends != null)
                            foreignFriends.AddRange(foreignfriends);

                    }

                    if (foreignFriends.Count != 0)
                        characteristic += $" Имеет {foreignFriends.Count} друзей иностранцев (см. Приложение иностранных друзей).";
                    else
                        characteristic += $" Не имеет друзей иностранцев.";

                }

                doc.Bookmarks["Characteristic"].Range.Text = characteristic;

                // Создает приложение военных фотографий
                if (userCrimes.Count != 0)
                {
                    // Создаём объект word
                    Microsoft.Office.Interop.Word._Application OneWord = new Microsoft.Office.Interop.Word.Application();

                    // Создаем документ
                    var OneDoc = OneWord.Documents.Add();

                    // Теперь формируем приложение
                    foreach (var item in userCrimes)
                    {
                        // Сохраняем картинку
                        // Первым делом необходимо сохранить картинку из byte[] в .png
                        if (item.Photo != null)
                        {
                            using (System.Drawing.Image image = System.Drawing.Image.FromStream(new MemoryStream(item.Photo)))
                            {
                                image.Save(@"D:\user.png", ImageFormat.Png);  // Or Png
                            }
                        }


                        object f = false;
                        object t = true;
                        object range = Type.Missing;

                        // Далее пишем инфу о преступлении

                        string info = $"Размещается по адресу: {item.WebAddressPost};";

                        OneWord.ActiveDocument.Characters.Last.Select();
                        OneWord.Selection.Collapse();
                        OneDoc.Content.InsertAfter($"{info}\n");

                        if (item.Photo != null)
                        {
                            OneWord.ActiveDocument.Characters.Last.Select();
                            OneWord.Selection.Collapse();
                            OneDoc.InlineShapes.AddPicture(@"D:\user.png", ref f, ref t, ref range);
                        }

                        OneWord.ActiveDocument.Characters.Last.Select();
                        OneWord.Selection.Collapse();
                        OneWord.Selection.InsertBreak(Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak);

                    }

                    // Выходим и закрываем
                    OneDoc.SaveAs2($@"{FileSource}\{user.Family} {user.Name} - список военных фотографий.docx");
                    OneDoc.Close();
                    OneDoc = null;
                    OneWord.Quit();
                    OneWord = null;
                }


                // Создает приложение иностранных друзей
                if (foreignFriends.Count != 0)
                {
                    // Создаём объект word
                    Microsoft.Office.Interop.Word._Application OneWord = new Microsoft.Office.Interop.Word.Application();

                    // Создаем документ
                    var OneDoc = OneWord.Documents.Add();

                    // Теперь формируем приложение
                    foreach (var item in foreignFriends)
                    {
                        // Сохраняем картинку
                        // Первым делом необходимо сохранить картинку из byte[] в .png
                        if (item.Photo != null)
                        {
                            using (System.Drawing.Image image = System.Drawing.Image.FromStream(new MemoryStream(item.Photo)))
                            {
                                image.Save(@"D:\user.png", ImageFormat.Png);  // Or Png
                            }
                        }


                        object f = false;
                        object t = true;
                        object range = Type.Missing;

                        // Далее пишем инфу об иностранном друге

                        string info = $"{item.Name} {item.Family}";

                        // если есть день рожденья, то добавить к тексту
                        if (item.BirthDay != null)
                            info += $", {item.BirthDay.Value.Day}.{item.BirthDay.Value.Month}.{item.BirthDay.Value.Year}";


                        // Добавить страну
                        info += $", {item.Country.Name}. Зарегистрирован(а) в социальной сети";
                        if (item.WebAddress.Contains("vk"))
                            info += " Вконтакте";
                        else if (item.WebAddress.Contains("facebook"))
                            info += " Фейсбук";
                        else
                            info += " Одноклассники";

                        info += $", адрес: {item.WebAddress}.";

                        OneWord.ActiveDocument.Characters.Last.Select();
                        OneWord.Selection.Collapse();
                        OneDoc.Content.InsertAfter($"{info}\n");

                        if (item.Photo != null)
                        {
                            OneWord.ActiveDocument.Characters.Last.Select();
                            OneWord.Selection.Collapse();
                            OneDoc.InlineShapes.AddPicture(@"D:\user.png", ref f, ref t, ref range);
                        }

                        OneWord.ActiveDocument.Characters.Last.Select();
                        OneWord.Selection.Collapse();
                        OneWord.Selection.InsertBreak(Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak);

                    }

                    // Выходим и закрываем
                    OneDoc.SaveAs2($@"{FileSource}\{user.Family} {user.Name} - список иностранных друзей.docx");
                    OneDoc.Close();
                    OneDoc = null;
                    OneWord.Quit();
                    OneWord = null;
                }



                // Сохраняем
                doc.SaveAs2($@"{FileSource}\{user.Family} {user.Name}.docx");
                // Закрываем документ
                doc.Close();
                doc = null;
                app = null;
            }
            catch (Exception)
            {
                // Если произошла ошибка, то
                // закрываем документ и выводим информацию
                doc.Close();
                doc = null;
                app = null;
            }
        }
    }
}
