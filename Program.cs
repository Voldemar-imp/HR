using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eho2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            List<string> posts = new List<string>();
            bool isMenuWork = true;

            names.AddRange(new string[] {"Попов Иван Богданович", "Нечаев Владимир Гордеевич", "Галкин Даниил Дамирович",
                "Павлов Максим Львович", "Акимов Максим Вадимович",
                "Новиков Илья Александрович", "Мартынов Дмитрий Вадимович"});
            posts.AddRange(new string[] { "Генеральный директор", "Исполнительный директор",
                "Финансовый директор", "Заведующий складом",
                "Мастер участка", "Менеджер по рекламе", "Начальник гаража" });

            while (isMenuWork)
            {
                Console.Clear();
                Console.WriteLine("Досье");
                Console.WriteLine("1) добавить досье \n2) вывести все досье \n3) удалить досье \n4) выход");
                ConsoleKeyInfo key = Console.ReadKey(true);
                Console.Clear();

                switch (key.KeyChar)
                {
                    case '1':
                        AddDossier(names, posts);
                        break;
                    case '2':
                        WriteDossiers(names, posts);
                        break;
                    case '3':
                        DeleteDossier(names, posts);
                        break;
                    case '4':
                        isMenuWork = false;
                        break;
                    default:
                        СhangeMessageСolor("Неверно выбрана команда. Для продолжения нажмите любую клавишу...");
                        break;
                }

                Console.ReadKey(true);
            }
        }

        static void AddDossier(List <string> names, List <string> posts)
        {
            Console.WriteLine("Добавить досье.");
            Console.WriteLine("Введите имя:");
            string addName = Console.ReadLine();
            Console.WriteLine("Введите должность:");
            string addPost = Console.ReadLine();
            Console.WriteLine("Под каким номером вы хотите поместить досье:");
            int addIndex = GetIndex(names.Count());
            names.Insert(addIndex, addName);
            posts.Insert(addIndex, addPost);
        }

        static int GetIndex(int listSize)
        {
            bool indexIsRight = false;
            int index = listSize;

            while (indexIsRight == false)
            {
                index = GetNumber () - 1;

                if (index >= 0 && index < listSize)
                {
                    indexIsRight = true;
                }
                else
                {
                    СhangeMessageСolor("Такого номера не существует в базе данных, попробуете еще раз", ConsoleColor.Yellow);
                }
            }

            return index;
        }

        static int GetNumber()
        {
            int number = 0;
            bool success = false;

            while (success == false)
            {
                string userInput = Console.ReadLine();

                success = int.TryParse(userInput, out number);
                if (success == false)
                {
                    Console.WriteLine($"Введенное значение: '{userInput}' не явлеяется целым числом, поробуйте еще раз.");
                }
            }

            return number;
        }

        static void WriteDossiers(List<string> names, List<string> posts)
        {
            for (int i = 0; i < posts.Count; i++)
            {
                Console.WriteLine ($"{i+1}.  {names[i]} - {posts[i]}");
            }
        }

        static void DeleteDossier(List<string> names, List<string> posts)
        {
            if (names.Count() == 0)
            {
                СhangeMessageСolor("Ошибка! База данных пуста!");
                return;
            }

            Console.WriteLine("Введите номер досье для удаления:");
            int deleteIndex = GetIndex(names.Count());

            if (deleteIndex >= 0 && deleteIndex < names.Count())
            {
                names.RemoveAt(deleteIndex);
                posts.RemoveAt(deleteIndex);
            }
            else
            {
                СhangeMessageСolor($"Досье с указанным номером '{deleteIndex}' в базе данных - нет"); 
            }
        }

        static void СhangeMessageСolor(string message, ConsoleColor сolor = ConsoleColor.Red)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = сolor;
            Console.WriteLine(message);
            Console.ForegroundColor = defaultColor;
        }
    }
}
