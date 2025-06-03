using System;
using System.Collections.Generic;
using System.IO;

namespace Task3
{
    internal sealed class Phonebook
    {
        private static Phonebook instance = null;

        private Phonebook(){ }
        public static Phonebook Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Phonebook();
                }
                return instance;
            }
        }
        public static List<Abonent> listAbonent = new List<Abonent>();
        public const string book = "./phonebook.txt";

        public static void AddAbonent(string name, string numberPhone)
        {
            Phonebook.listAbonent.Add(new Abonent(name, numberPhone));
            WriteToInPhonebook();
        }
        internal static void DeleteAbonent(int id)
        {
            Phonebook.listAbonent.RemoveAt(id);
            WriteToInPhonebook();
        }
        internal static void UpdateAbonent(string updateString, int id, int flag)
        {
            if (flag == 1)
            {
                Phonebook.listAbonent[id].name = updateString;
            }
            else if (flag ==2)
            {
                Phonebook.listAbonent[id].numberPhone = updateString;
            }
            WriteToInPhonebook();
        }
        internal static void SearchAbonent(string searchString, int flag)
        {
            string foundUser = "Данных нет";
            foreach (Abonent list in Phonebook.listAbonent)
            {
                if ((flag == 1) && (list.name == searchString))
                {
                    foundUser = list.numberPhone;
                }
                else if ((flag == 2) && (list.numberPhone == searchString))
                {
                    foundUser = list.name;
                }
            }
            Console.Write(foundUser);
            Console.ReadKey();
        }
        internal static void ReadPhoneBook()
        {
            Phonebook.listAbonent.Clear();
            StreamReader str = new StreamReader(book);
            string[] listPhonebook = File.ReadAllLines(book);
            for (int i = 0; i < listPhonebook.Length; i++)
            {
                int index = listPhonebook[i].IndexOf(" ");
                string nameAbonent = listPhonebook[i].Substring(0, index);
                string numberAbonent = listPhonebook[i].Substring(index + 1);
                Phonebook.listAbonent.Add(new Abonent(nameAbonent, numberAbonent));
            }
            str.Close();
        }
        internal static void WriteToInPhonebook()
        {
            File.WriteAllText(book, string.Empty);
            StreamWriter str = new StreamWriter(book);
            foreach (Abonent list in Phonebook.listAbonent)
            {
                str.WriteLine(list.name + " " + list.numberPhone);
            }
            str.Close();
        }
        internal static void PrintAbonent()
        {
            ReadPhoneBook();
            int id = 1;
            if (Phonebook.listAbonent.Count > 0)
            {
                foreach (Abonent list in Phonebook.listAbonent)
                {
                    Console.WriteLine(id + " " + list.name + " " + list.numberPhone);
                    id++;
                }
            }
            else
            {
                Console.WriteLine("Книга пустая");
            }
        }
        internal static bool CheckAddNewAbonent(string name, string numberPhone)
        {
            foreach (Abonent list in Phonebook.listAbonent)
            {
                if (list.name == name || list.numberPhone == numberPhone)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
