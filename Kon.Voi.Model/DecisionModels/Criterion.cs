namespace Kon.Voi.Model.DecisionModels
{
    /// <summary>
    /// 
    /// </summary>
    public class Criterion
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>
        /// The rate.
        /// </value>
        public int Rate { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the criterion priority.
        /// </summary>
        /// <value>
        /// The criterion priority.
        /// </value>
        public double CriterionPriority { get; set; }

        /// <summary>
        /// Gets or sets the value priority.
        /// </summary>
        /// <value>
        /// The value priority.
        /// </value>
        public double ValuePriority { get; set; }

        /// <summary>
        /// Gets or sets the value rate.
        /// </summary>
        /// <value>
        /// The value rate.
        /// </value>
        public int ValueRate { get; set; }
    }
}
