using System.Linq;
using Baruah.MathsEngine.Attribute;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Arithmetic
{
    /// <summary>
    /// A math node that multiplies multiple child nodes together.
    /// </summary>
    /// <remarks>
    /// If any node evaluates to zero the calculation exits early
    /// since the result must be zero.
    /// </remarks>
    [MathNodeCategory("Arithmetic")]
    public class MultiplicationNode : ArithmeticBase
    {
        /// <summary>
        /// Calculates the product of all child nodes.
        /// </summary>
        /// <param name="parameter">Runtime parameters passed to child nodes.</param>
        /// <summary>
        /// Computes the product of this node's child nodes evaluated with the provided parameters.
        /// </summary>
        /// <remarks>
        /// Null child nodes are treated as 1 (multiplicative identity). Evaluation stops early and returns 0 as soon as the running product becomes 0.
        /// </remarks>
        /// <returns>The product of all child node values after evaluation.</returns>
        public override float Calculate(object[] parameter)
        {
            float ret = 1;

            foreach (var val in _values)
            {
                ret *= val != null ? val.Calculate(parameter) : 1;

                if (ret == 0)
                {
                    return 0;
                }
            }

            return ret;
        }

        /// <summary>
        /// Returns the equation representation of the multiplication.
        /// </summary>
        public override string ToEquation() =>
            "(" + string.Join(" * ", _values.Select(v => v == null ? "?" : v.ToEquation())) + ")";
    }
}
