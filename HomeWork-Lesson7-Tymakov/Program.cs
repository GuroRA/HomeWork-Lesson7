using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeWork_Lesson7_Tymakov
{
    internal class Program
    {
        static void Task1()
        {
            BankAccount BobsAccount = new BankAccount(344.4M, AccountType.currentAccount);
            BankAccount LeraAccount = new BankAccount(345.4M, AccountType.currentAccount);
            BobsAccount.GetAccountData();
            LeraAccount.GetAccountData();
            LeraAccount.TransferMoney(BobsAccount, 45);
            BobsAccount.GetAccountData();
            LeraAccount.GetAccountData();
        }


        static string ReverseString(string text)
        {
            char[] symbols = text.ToCharArray();
            Array.Reverse(symbols);
            return new string(symbols);
        }

        static void Task2() 
        {
            Console.WriteLine("Упражнение 8.2\n");
            string text = "Affegdgiabba";
            Console.WriteLine($"Исходная строка: {text}\nПеревёрнутая строка: {ReverseString(text)}");
        }

        /// <summary>
        /// Возвращает путь папки с пректом
        /// </summary>
        /// <returns></returns>
        static string GetProjectPath()
        {
            return Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        }

        /// <summary>
        /// Возвращает текст в большом регистре из файла если он существует
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        static string GetFileTextInUpper(string fileName, string output)
        {
            string projectDirectory = GetProjectPath();

            if (File.Exists($"{projectDirectory}/{fileName}"))
            {
                output = File.ReadAllText($"{projectDirectory}/{fileName}").ToUpper();
            }
            else
            {
                Console.WriteLine("Файла не существует");
            }
            return output;
        }

        static void Task3()
        {
            Console.WriteLine("Упражнение 8.3\nВведите название файла(info.txt)");
            Console.WriteLine(GetFileTextInUpper(Console.ReadLine()!, ""));
        }

        static bool IsFormattableImplementedIs(object param)
        {
            return param is IFormattable;
        }

        static bool IsFormattableImplementedAs(object param)
        {
            return param as IFormattable != null;
        } 
        static void Task4()
        {
            Console.WriteLine($"{IsFormattableImplementedIs(BankAccount.Equals)}\n{IsFormattableImplementedAs(BankAccount.Equals)}");
        }


        static string SearchMail(ref string s)
        {
            return $"{s.Split('#')[1].Trim()}\n";
        }

        static void Task5()
        {
            var lines = File.ReadAllLines($"{GetProjectPath()}/FIO_email.txt");
            for (int i = 0; i < lines.Length; i += 1)
            {
                string line = lines[i];
                File.AppendAllText($"{GetProjectPath()}/emails.txt", SearchMail(ref line));
            }
        }

        static void Task6()
        {
            uint countOfSongs = 0;
            Console.Write("Введите кол-во песен в списке: ");
            uint.TryParse(Console.ReadLine()!, out countOfSongs);
            List<Song> list = new List<Song>();

            for (int i = 0; i < countOfSongs; i++)
            {
                Console.WriteLine("Введите название песни, затем исполнителя");
                list.Add(new Song(Console.ReadLine()!, Console.ReadLine()!, i - 1 >= 0 ? list[i - 1] : null));
            }

            foreach (Song song in list)
            { 
                Console.WriteLine(song.Title());
            }
            if (list[1].Equals(list[1].Prev))
            {
                Console.WriteLine("Имя исполнителя и название первой и второй песни совпадают");
            }
            else
            {
                Console.WriteLine("Имя исполнителя и название первой и второй песни не совпадают");
            }
        }
        static void Main(string[] args)
        {
            /*
             В класс банковский счет, созданный в упражнениях 7.1- 7.3 добавить
             метод, который переводит деньги с одного счета на другой. У метода два параметра: ссылка
             на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.
            */
            Task1();

            /*
             Реализовать метод, который в качестве входного параметра принимает
             строку string, возвращает строку типа string, буквы в которой идут в обратном порядке.
             Протестировать метод.
            */
            Task2();

            /*
             Написать программу, которая спрашивает у пользователя имя файла. Если
             такого файла не существует, то программа выдает пользователю сообщение и заканчивает
             работу, иначе в выходной файл записывается содержимое исходного файла, но заглавными
             буквами.
            */
            Task3();
            /*
             Реализовать метод, который проверяет реализует ли входной параметр
             метода интерфейс System.IFormattable. Использовать оператор is и as. (Интерфейс
             IFormattable обеспечивает функциональные возможности форматирования значения объекта
             в строковое представление.) 
            */
            Task4();
            /*
            Домашнее задание 8.1 Работа со строками. Дан текстовый файл, содержащий ФИО и e-mail
            адрес. Разделителем между ФИО и адресом электронной почты является символ #:
            Иванов Иван Иванович # iviviv@mail.ru
            Петров Петр Петрович # petr@mail.ru
            Сформировать новый файл, содержащий список адресов электронной почты.
            Предусмотреть метод, выделяющий из строки адрес почты. Методу в
            качестве параметра передается символьная строка s, e-mail возвращается в той же строке s:
            public void SearchMail (ref string s). 
            */
            Task5();

            /*
            Список песен. В методе Main создать список из четырех песен. В
            цикле вывести информацию о каждой песне. Сравнить между собой первую и вторую
            песню в списке. Песня представляет собой класс с методами для заполнения каждого из
            полей, методом вывода данных о песне на печать, методом, который сравнивает между
            собой два объекта:
            class Song{
            string name; //название песни
            string author; //автор песни
            Song prev; //связь с предыдущей песней в списке
            //метод для заполнения поля name
            //метод для заполнения поля author
            //метод для заполнения поля prev
            //метод для печати названия песни и ее исполнителя
            public string Title(){}
            //метод, который сравнивает между собой два объекта-песни:
            public bool override Equals(object d) { ...}
            */
            Task6();
            Console.ReadKey();
        }
    }
}
