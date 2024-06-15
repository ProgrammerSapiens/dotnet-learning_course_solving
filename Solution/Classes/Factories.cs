namespace Solution.Classes
{
    internal class Factories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Factories() { }
        public Factories(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
