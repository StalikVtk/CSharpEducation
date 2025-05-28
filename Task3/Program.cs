using System;
namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Phonebook phonebook = Phonebook.Instance;
            bool closeBook = true;
            while (closeBook)
            {
                Console.Clear();
                Console.Title = "Телефонная книга";
                Phonebook.PrintAbonent();
                Console.WriteLine("\n\tМеню:");
                Console.WriteLine("\t\t1. Создать \n\t\t2. Найти \n\t\t3. Обновить \n\t\t4. Удалить \n\t\t5. Выйти");
                Console.Write("\nУкажите необходимый пункт меню: ");
                int itemMenu = Convert.ToInt32(Console.ReadLine());

                switch (itemMenu)
                {
                    case 1:
                        Console.Write("Введите имя: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите номер: ");
                        string numberPhone = Console.ReadLine();

                        if (Phonebook.CheckAddNewAbonent(name, numberPhone))
                        {
                            Phonebook.AddAbonent(name, numberPhone);
                            break;
                        }
                        Console.WriteLine("Абонент уже существует!");
                        Console.ReadKey();
                        break;
                    case 2:
                        Phonebook.SearchAbonent();
                        break;
                    case 3:
                        Console.Write("Укажите порядковый номер абонента: ");
                        Phonebook.UpdateAbonent();
                        break;
                    case 4:
                        Console.Write("Укажите порядковый номер абонента: ");
                        Phonebook.DeleteAbonent();
                        break;
                    case 5:
                        closeBook = false;
                        Console.WriteLine("Книга закрыта.");
                        break;
                    default:
                        Console.WriteLine($"Пункта под номером {itemMenu}, не существует!");
                        Console.ReadKey();
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
