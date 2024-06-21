namespace Lesson_1_Part_1.Classes
{
    /// <summary>
    /// Represets a Deal with a sum, id, and Date 
    /// </summary>
    internal class Deal
    {
        /// <summary>
        /// Gets or sets the id of the deal 
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the sum of the deal
        /// </summary>
        public int Sum { get; set; }

        /// <summary>
        /// Gets or sets the date of the deal
        /// </summary>
        public DateTime Date { get; set; }
    }
}
