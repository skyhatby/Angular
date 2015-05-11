using System.Collections.Generic;

namespace WebApp.Models.Decision
{
    /// <summary>
    /// 
    /// </summary>
    public class DecisionViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the session.
        /// </summary>
        /// <value>
        /// The name of the session.
        /// </value>
        public string SessionName { get; set; }

        /// <summary>
        /// Gets or sets the decision array.
        /// </summary>
        /// <value>
        /// The decision array.
        /// </value>
        public virtual IEnumerable<DecisionSubjectViewModel> DecisionArray { get; set; }
    }
}