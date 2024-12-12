namespace HomeWork7_File
{
    class Developers : Worker
    {
        private string acceptedTask = "разработать";
        public Developers(string name, Position position) : base(name, position)
        {
            Name = name;
            Position = position;
        }
        public bool IsTaskCorrect(string task)
        {
            return task.Contains(acceptedTask);
        }
    }
}
