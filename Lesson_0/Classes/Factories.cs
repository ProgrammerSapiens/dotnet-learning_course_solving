namespace Lesson_0.Classes
{
    /// <summary>
    /// Represents a factory with an Id, name, and description
    /// </summary>
    internal class Factories
    {
        /// <summary>
        /// Gets or sets the Id of the factory
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the factory
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the factory
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Factories"/> class.
        /// </summary>
        public Factories() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Factories"/> class with the specified Id, name, and description
        /// </summary>
        /// <param name="id">The ID of the factory</param>
        /// <param name="name">The name of the factory</param>
        /// <param name="description">The description of the factory</param>
        public Factories(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
