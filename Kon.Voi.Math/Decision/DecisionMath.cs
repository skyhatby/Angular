using System;
using System.Collections.Generic;
using System.Linq;

namespace Kon.Voi.Math.Decision
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDecisionMath
    {
        /// <summary>
        /// Counts the priorities.
        /// </summary>
        /// <param name="rateArray">The rate array.</param>
        /// <returns></returns>
        double[] CountPriorities(double[] rateArray);
    }

    /// <summary>
    /// 
    /// </summary>
    public class DecisionMath : IDecisionMath
    {
        /// <summary>
        /// Counts the priorities.
        /// </summary>
        /// <param name="rateArray">The rate array.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="OverflowException">The array is multidimensional and contains more than <see cref="F:System.Int32.MaxValue" /> elements.</exception>
        public double[] CountPriorities(double[] rateArray)
        {
            double[] interimArray = this.ThirdStepCounting(rateArray);
            double interimArraySum = interimArray.Sum();
            int length = rateArray.Length;
            double[] result = new double[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = interimArray[i] / interimArraySum;
            }
            return result;
        }

        /// <summary>
        /// Thirds the step counting.
        /// </summary>
        /// <param name="rateArray">The rate array.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">rateArray</exception>
        private double[] ThirdStepCounting(IList<double> rateArray)
        {
            if (rateArray == null) throw new ArgumentNullException("rateArray");
            var length = rateArray.Count;
            var result = new double[length];
            for (var i = 0; i < length; i++)
            {
                result[i] = SecondStepCounting(rateArray, i);
            }
            return result;
        }

        /// <summary>
        /// Seconds the step counting.
        /// </summary>
        /// <param name="rateArray">The rate array.</param>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        private double SecondStepCounting(IList<double> rateArray, int number)
        {
            var fas = FirstStepCounting(rateArray, number)
                .Aggregate<double, double>(1, (current, d) => current * d);
            var result = System.Math.Pow(fas, 1.0 / rateArray.Count);
            return result;
        }

        /// <summary>
        /// Firsts the step counting.
        /// </summary>
        /// <param name="rateArray">The rate array.</param>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        private IEnumerable<double> FirstStepCounting(IList<double> rateArray, int number)
        {
            var length = rateArray.Count;
            var result = new double[length];
            for (var i = 0; i < length; i++)
            {
                result[i] = rateArray[number] / rateArray[i];
            }
            return result;
        }
    }
}
