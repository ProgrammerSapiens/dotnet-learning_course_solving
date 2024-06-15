namespace Solution.Classes
{
    internal class Tanks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Volume { get; set; }
        public int MaxVolume { get; set; }
        public int UnitId { get; set; }
        public Tanks() { }
        public Tanks(int id, string name, string description, int volume, int maxVolume, int unitId)
        {
            Id = id;
            Name = name;
            Description = description;
            Volume = volume;
            MaxVolume = maxVolume;
            UnitId = unitId;
        }
    }
}
