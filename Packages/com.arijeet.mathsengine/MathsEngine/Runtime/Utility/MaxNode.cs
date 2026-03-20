using Baruah.MathsEngine.Attribute;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Utility
{
    /// <summary>
    /// Returns the larger of two values.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.Max"/>.
    /// </remarks>
    [MathNodeCategory("Utility")]
    public class MaxNode : BaseRangeNode
    {
        /// <summary>
        /// Calculates the maximum value.
        /// <summary>
        /// Selects the larger value produced by the node's two operands.
        /// </summary>
        /// <param name="parameter">Evaluation context forwarded to each operand's Calculate method.</param>
        /// <returns>The larger evaluated operand as a float; `Mathf.Infinity` if either operand is null.</returns>
        public override float Calculate(object[] parameter)
        {
            if (_a == null || _b == null)
            {
                return Mathf.Infinity;
            }
            
            return Mathf.Max(_a.Calculate(parameter), _b.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// <summary>
                /// Produces the equation string "Max(a,b)", using each operand's equation or "?" for a missing operand.
                /// </summary>
                /// <returns>The equation in the form Max(x,y), where x and y are operand equations or "?" if the operand is null.</returns>
        public override string ToEquation() =>
            "Max(" + (_a != null ? _a.ToEquation() : "?") + ","
                + (_b != null ? _b.ToEquation() : "?") + ")";
    }
}
