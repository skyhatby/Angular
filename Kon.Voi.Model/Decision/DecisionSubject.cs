using System.Collections.Generic;

namespace Kon.Voi.Model.Decision
{
    /// <summary>
    /// 
    /// </summary>
    public class DecisionSubject
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
        /// Gets or sets the final rate.
        /// </summary>
        /// <value>
        /// The final rate.
        /// </value>
        public double FinalRate { get; set; }

        /// <summary>
        /// Gets or sets the criteria array.
        /// </summary>
        /// <value>
        /// The criteria array.
        /// </value>
        public IEnumerable<Criterion> CriteriaArray { get; set; }
    }
}
