using Kon.Voi.Math;
using Kon.Voi.Math.Decision;
using Microsoft.Practices.Unity;

namespace Kon.Voi.Workflow
{
    /// <summary>
    /// 
    /// </summary>
    public class UnityConfig
    {
        /// <summary>
        /// Registers the types.
        /// </summary>
        /// <param name="container">The Unity <paramref name="container"/>.</param>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IMathManager, MathManager>();
            container.RegisterType<IDecisionMath, DecisionMath>();
        }
    }
}