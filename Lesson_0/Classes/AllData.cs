namespace Lesson_0.Classes
{
    /// <summary>
    /// Represets the structure of storing all information about factories, units, and tanks
    /// </summary>
    internal class AllData
    {
        /// <summary>
        /// Gets or sets the list of factories
        /// </summary>
        /// <value>
        /// A list of <see cref="Factories"/> objects representing the factories
        /// </value>
        public List<Factories> Factories { get; set; }

        /// <summary>
        /// Gets or sets the list of units
        /// </summary>
        /// <value>
        /// A list of <see cref="Units"/> objects representing the units
        /// </value>
        public List<Units> Units { get; set; }

        /// <summary>
        /// Gets or sets the list of tanks
        /// </summary>
        /// <value>
        /// A list of <see cref="Tanks"/> objects representing the tanks
        /// </value>
        public List<Tanks> Tanks { get; set; }
        public AllData()
        {
            Factories = new List<Factories>();
            Units = new List<Units>();
            Tanks = new List<Tanks>();
        }
    }
}
