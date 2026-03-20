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
        /// </summary>
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
        /// </summary>
        public override string ToEquation() =>
            "Min(" + (_a != null ? _a.ToEquation() : "?") + ","
            + (_b != null ? _b.ToEquation() : "?") + ")";
    }
}
