using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Kon.Voi.Model.DecisionModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Gets or sets the hometown.
        /// </summary>
        /// <value>
        /// The hometown.
        /// </value>
        public string Hometown { get; set; }

        /// <summary>
        /// Gets or sets the decision.
        /// </summary>
        /// <value>
        /// The decision.
        /// </value>
        public Decision Decision { get; set; }

        /// <summary>
        /// Generates the user identity asynchronous.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        /// <summary>
        /// Gets or sets the decisions.
        /// </summary>
        /// <value>
        /// The decisions.
        /// </value>
        public DbSet<Decision> Decisions { get; set; }

        /// <summary>
        /// Gets or sets the decision subjects.
        /// </summary>
        /// <value>
        /// The decision subjects.
        /// </value>
        public DbSet<DecisionSubject> DecisionSubjects { get; set; }

        /// <summary>
        /// Gets or sets the criteria.
        /// </summary>
        /// <value>
        /// The criteria.
        /// </value>
        public DbSet<Criterion> Criteria { get; set; }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}