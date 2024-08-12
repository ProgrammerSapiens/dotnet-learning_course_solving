using Lesson_2_Part_2.Interfaces;
using System.Collections.Generic;

namespace Lesson_2_Part_2.Classes.Descriptive
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
        public List<IHaveName> Factories { get; set; }

        /// <summary>
        /// Gets or sets the list of units
        /// </summary>
        /// <value>
        /// A list of <see cref="Units"/> objects representing the units
        /// </value>
        public List<IHaveName> Units { get; set; }

        /// <summary>
        /// Gets or sets the list of tanks
        /// </summary>
        /// <value>
        /// A list of <see cref="Tanks"/> objects representing the tanks
        /// </value>
        public List<IHaveName> Tanks { get; set; }
        public AllData()
        {
            Factories = new List<IHaveName>();
            Units = new List<IHaveName>();
            Tanks = new List<IHaveName>();
        }
    }
}
