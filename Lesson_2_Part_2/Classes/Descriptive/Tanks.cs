using Lesson_2_Part_2.Interfaces;

namespace Lesson_2_Part_1.Classes.Descriptive
{
    /// <summary>
    /// Represents a tank with an Id, name, description, volume, maxVolume, and UnitId
    /// </summary>
    internal class Tanks : IHaveName
    {
        /// <summary>
        /// Gets or sets the Id of the tank
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the tank
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the tank
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the volume of the tank
        /// </summary>
        public int Volume { get; set; }

        /// <summary>
        /// Gets or sets the maxVolume of the tank
        /// </summary>
        public int MaxVolume { get; set; }

        /// <summary>
        /// Gets or sets the unitId of the tank
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// Initialize a new instance of the <see cref="Tanks"/> class
        /// </summary>
        public Tanks() { }

        /// <summary>
        /// Initialize a new instance of the <see cref="Tanks"/> class with the specified id, name, description, volume, maxVolume, and unitId
        /// </summary>
        /// <param name="id">The id of the tank</param>
        /// <param name="name">The name of the tank</param>
        /// <param name="description">The description of the tank</param>
        /// <param name="volume">The volume of the tank</param>
        /// <param name="maxVolume">The maxVolume of the tank</param>
        /// <param name="unitId">The unitId where the tank is located</param>
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
