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
        /// </summary>
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
        /// </summary>
        public override string ToEquation() =>
            "Max(" + (_a != null ? _a.ToEquation() : "?") + ","
                + (_b != null ? _b.ToEquation() : "?") + ")";
    }
}
