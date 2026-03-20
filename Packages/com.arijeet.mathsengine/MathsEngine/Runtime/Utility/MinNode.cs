using Baruah.MathsEngine.Attribute;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Utility
{
    /// <summary>
    /// Returns the smaller of two values.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.Min"/>.
    /// </remarks>
    [MathNodeCategory("Utility")]
    public class MinNode : BaseRangeNode
    {
        /// <summary>
        /// Calculates the minimum value.
        /// <summary>
        /// Computes the minimum of the two operand nodes.
        /// </summary>
        /// <param name="parameter">Evaluation inputs forwarded to the operand nodes.</param>
        /// <returns>`Mathf.NegativeInfinity` if either operand is null; otherwise the smaller float value produced by the two operands.</returns>
        public override float Calculate(object[] parameter)
        {
            if (_a == null || _b == null)
            {
                return Mathf.NegativeInfinity;
            }
            
            return Mathf.Min(_a.Calculate(parameter), _b.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// <summary>
            /// Produces the node's equation as a Min(a,b) expression.
            /// </summary>
            /// <returns>The equation string in the form "Min(x,y)", where each operand is the operand's equation or "?" when that operand is missing.</returns>
        public override string ToEquation() =>
            "Min(" + (_a != null ? _a.ToEquation() : "?") + ","
            + (_b != null ? _b.ToEquation() : "?") + ")";
    }
}
