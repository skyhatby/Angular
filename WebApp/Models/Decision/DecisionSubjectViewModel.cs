using System.Collections.Generic;

namespace WebApp.Models.Decision
{
    /// <summary>
    /// 
    /// </summary>
    public class DecisionSubjectViewModel
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
        public IEnumerable<CriterionViewModel> CriteriaArray { get; set; }
    }
}
