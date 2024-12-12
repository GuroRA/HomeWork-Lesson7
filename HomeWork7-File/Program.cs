using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Directorate Timur = new Directorate("Тимур", Position.CEO);
            Directorate Rashid = new Directorate("Рашид", Position.FINANCE_DIRECTOR);
            Directorate OIlham = new Directorate("О Ильхам", Position.AUTOMATION_DIRECTOR);
            Accounting Lucas = new Accounting("Лукас", Position.HEAD);
            Superiors Orkadi = new Superiors("Оркадий", Position.SUPERIOR_HEAD);
            Superiors Volodea = new Superiors("Володя", Position.SUPERIOR_SUBSTITUTE);
            SystemEngineers Ilshat = new SystemEngineers("Ильшат", Position.HEAD);
            SystemEngineers Ivan = new SystemEngineers("Иваныч", Position.SUBSTITUTE);
            SystemEngineers Ilia = new SystemEngineers("Илья", Position.EMPLOYEE);
            SystemEngineers Vitea = new SystemEngineers("Витя", Position.EMPLOYEE);
            SystemEngineers Zenea = new SystemEngineers("Женя", Position.EMPLOYEE);
            Developers Sergey = new Developers("Сергей", Position.HEAD);
            Developers Laisan = new Developers("Ляйсан", Position.SUBSTITUTE);
            Developers Marat = new Developers("Марат", Position.EMPLOYEE);
            Developers Dina = new Developers("Дина", Position.EMPLOYEE);
            Developers Ildar = new Developers("Ильдар", Position.EMPLOYEE);
            Developers Anton = new Developers("Ильдар", Position.EMPLOYEE);

            Console.WriteLine("Введите задание");
            string task = Console.ReadLine();

            OIlham.SendTheTask(task, Orkadi, Vitea);
            if (Vitea.IsTaskCorrect(task))
            {
                Console.WriteLine("Работник может справится с этой задачей");
            }
            else
            {
                Console.WriteLine("Задача вне прлномочий работника");
            }
            Console.ReadKey();
        }
    }
}
