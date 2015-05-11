using System.Collections.Generic;

namespace Kon.Voi.Model.Decision
{
    /// <summary>
    /// 
    /// </summary>
    public class Decision
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
        public virtual IEnumerable<DecisionSubject> DecisionArray { get; set; }
    }
}
