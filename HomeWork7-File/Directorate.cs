namespace HomeWork7_File
{
    class Directorate : Worker
    {
        public Worker Subordinates { private get; set; }
        public Directorate(string name, Position position, Worker subordinates) : base(name, position)
        {
            Name = name;
            Position = position;
            Subordinates = subordinates;
        }
        public Directorate(string name, Position position) : base(name, position)
        {
            Name = name;
            Position = position;
        }
    }
}
