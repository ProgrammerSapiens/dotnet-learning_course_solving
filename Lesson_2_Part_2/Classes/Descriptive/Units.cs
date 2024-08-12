using Lesson_2_Part_2.Interfaces;

namespace Lesson_2_Part_2.Classes.Descriptive
{
    /// <summary>
    /// Represents a unit with an Id, name, description, and factoryID
    /// </summary>
    public class Units : IHaveName
    {
        /// <summary>
        /// Gets or sets the Id of the unit
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the unit
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the unit
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the factoryId where the unit is located
        /// </summary>
        public int FactoryId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Units"/> class
        /// </summary>
        public Units() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Units"/> class with the specified id, name, description, and factoryId
        /// </summary>
        /// <param name="id">The Id of the unit</param>
        /// <param name="name">The name of the unit</param>
        /// <param name="description">The description of the unit</param>
        /// <param name="factoryId">The factoryId where the unit is located</param>
        public Units(int id, string name, string description, int factoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            FactoryId = factoryId;
        }
    }
}
