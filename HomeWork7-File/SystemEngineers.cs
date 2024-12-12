namespace HomeWork7_File
{
    class SystemEngineers : Worker
    {
        private string acceptedTask = "сеть";
        public SystemEngineers(string name, Position position) : base(name, position)
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
