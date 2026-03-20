using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Utility.Range
{
    /// <summary>
    /// Calculates the interpolation factor between two values.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.InverseLerp"/>.
    /// Determines where a value lies between two endpoints.
    /// </remarks>
    [MathNodeCategory("Utility")]
    public class InverseLerp : BaseMathNode
    {
        /// <summary>
        /// Lower bound of the range.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _a;

        /// <summary>
        /// Upper bound of the range.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _b;

        /// <summary>
        /// Value whose relative position is calculated.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _t;

        /// <summary>
        /// Calculates the normalized interpolation factor.
        /// <summary>
        /// Computes the normalized interpolation factor of _t between _a and _b using Unity's Mathf.InverseLerp; returns 0 if any input node is null.
        /// </summary>
        /// <param name="parameter">Evaluation context passed to the child nodes' Calculate methods.</param>
        /// <returns>Normalized value between 0 and 1 representing _t's relative position between _a and _b; `0` if any node is null.</returns>
        public override float Calculate(object[] parameter)
        {
            if (_a == null || _b == null || _t == null)
            {
                return 0f;
            }
            
            return Mathf.InverseLerp(
                _a.Calculate(parameter),
                _b.Calculate(parameter),
                _t.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// <summary>
                /// Builds a symbolic equation for the inverse linear interpolation of the three child nodes.
                /// </summary>
                /// <returns>
                /// A string in the form <c>InverseLerp(a,b,t)</c> where each argument is the corresponding child's <c>ToEquation()</c> result or <c>?</c> if that child is null.
                /// </returns>
        public override string ToEquation() =>
            "InverseLerp(" 
                + (_a != null ? _a.ToEquation() : "?") + "," 
                + (_b != null ? _b.ToEquation() : "?") + "," 
                + (_t != null ? _t.ToEquation() : "?") + ")";
    }
}
