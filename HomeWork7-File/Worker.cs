using System;

namespace HomeWork7_File
{
    enum Position
    {
        EMPLOYEE,
        SUBSTITUTE,
        HEAD,
        SUPERIOR_HEAD,
        SUPERIOR_SUBSTITUTE,
        FINANCE_DIRECTOR,
        AUTOMATION_DIRECTOR,
        CEO,
    }
    abstract class Worker
    {
        public string Name { get; set; }
        public Position Position {  get; set; }

        public void SendTheTask(string task, Worker sender, Worker receiver)
        {
            if (sender.Position == Position.EMPLOYEE)
            {
                Console.WriteLine("Работник не может отправлять запрос");
            }
            else if (sender.Position == Position.SUBSTITUTE && receiver.Position == Position.EMPLOYEE && sender.GetType() == receiver.GetType())
            {

                Console.WriteLine($"{sender.Name} может передать задание: {task} работнику {receiver.Name}");
            }
            else if (sender.Position == Position.HEAD && (receiver.Position == Position.SUBSTITUTE || receiver.Position == Position.EMPLOYEE) && sender.GetType() == receiver.GetType())
            {
                Console.WriteLine($"{sender.Name} может передать задание: {task} работнику {receiver.Name}");
            }
            else if (sender.Position == Position.SUPERIOR_HEAD && (receiver.Position == Position.SUBSTITUTE || receiver.Position == Position.EMPLOYEE || receiver.Position == Position.HEAD || receiver.Position == Position.SUPERIOR_SUBSTITUTE) && (receiver is Superiors || receiver is SystemEngineers || receiver is Developers))
            {
                Console.WriteLine($"{sender.Name} может передать задание: {task} работнику {receiver.Name}");
            }
            else if (sender.Position == Position.SUPERIOR_SUBSTITUTE && (receiver.Position == Position.SUBSTITUTE || receiver.Position == Position.EMPLOYEE || receiver.Position == Position.HEAD) && (receiver is SystemEngineers || receiver is Developers))
            {
                Console.WriteLine($"{sender.Name} может передать задание: {task} работнику {receiver.Name}");
            }
            else if (sender.Position == Position.AUTOMATION_DIRECTOR && (receiver.Position == Position.SUBSTITUTE || receiver.Position == Position.EMPLOYEE || receiver.Position == Position.HEAD) && (receiver is Superiors || receiver is SystemEngineers || receiver is Developers))
            {
                Console.WriteLine($"{sender.Name} может передать задание: {task} работнику {receiver.Name}");
            }
            else if (sender.Position == Position.FINANCE_DIRECTOR && (receiver.Position == Position.SUBSTITUTE || receiver.Position == Position.EMPLOYEE || receiver.Position == Position.HEAD) && receiver is Accounting)
            {
                Console.WriteLine($"{sender.Name} может передать задание: {task} работнику {receiver.Name}");
            }
            else if (sender.Position == Position.CEO)
            {
                Console.WriteLine($"{sender.Name} может передать задание: {task} работнику {receiver.Name}");
            }
            else
            {
                Console.WriteLine($"{sender.Name} не может передать задание: {task} работнику {receiver.Name}");
            }
        }


        protected Worker(string name, Position position)
        {
            Name = name;
            Position = position;
        }
    }
}
