using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Utility.Range
{
    /// <summary>
    /// Linearly interpolates between two values.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.Lerp"/>.
    /// The interpolation parameter <c>t</c> typically ranges from 0 to 1.
    /// </remarks>
    [MathNodeCategory("Utility/Range")]
    public class Lerp : BaseMathNode
    {
        /// <summary>
        /// Starting value.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _a;

        /// <summary>
        /// Ending value.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _b;

        /// <summary>
        /// Interpolation parameter.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _t;

        /// <summary>
        /// Calculates the interpolated value.
        /// <summary>
        /// Computes the linear interpolation between the `_a` and `_b` node values using `_t` as the interpolation factor.
        /// </summary>
        /// <param name="parameter">Runtime parameters forwarded to each node's Calculate method.</param>
        /// <returns>The interpolated float value; returns 0f if any of the `_a`, `_b`, or `_t` nodes is null.</returns>
        public override float Calculate(object[] parameter)
        {
            if (_a == null || _b == null || _t == null)
            {
                return 0f;
            }
            
            return Mathf.Lerp(
                _a.Calculate(parameter),
                _b.Calculate(parameter),
                _t.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// <summary>
                /// Builds a string representation of the linear interpolation expression "Lerp(a,b,t)".
                /// </summary>
                /// <returns>A string in the form Lerp(aEquation,bEquation,tEquation) where each of aEquation, bEquation, and tEquation is the corresponding node's ToEquation() or "?" if that node is null.</returns>
        public override string ToEquation() =>
            "Lerp("
                + (_a != null ? _a.ToEquation() : "?") + "," 
                + (_b != null ? _b.ToEquation() : "?") + "," 
                + (_t != null ? _t.ToEquation() : "?") + ")";
    }
}
