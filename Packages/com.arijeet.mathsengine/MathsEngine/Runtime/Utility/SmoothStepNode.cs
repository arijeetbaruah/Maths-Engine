using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Utility
{
    /// <summary>
    /// Performs smooth interpolation between two values.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.SmoothStep"/> to interpolate between
    /// the start and end values with smooth easing.
    /// </remarks>
    [MathNodeCategory("Utility")]
    public class SmoothStepNode : BaseMathNode
    {
        /// <summary>
        /// Starting value.
        /// </summary>
        [SerializeField, SerializeReference]
        private BaseMathNode _from;

        /// <summary>
        /// Ending value.
        /// </summary>
        [SerializeField, SerializeReference]
        private BaseMathNode _to;

        /// <summary>
        /// Interpolation parameter.
        /// </summary>
        [SerializeField, SerializeReference]
        private BaseMathNode _t;

        /// <summary>
        /// Calculates the smooth interpolation result.
        /// <summary>
        /// Computes a smooth interpolation between the evaluated from and to nodes using the evaluated t node.
        /// If all three nodes (_from, _to, _t) are null, returns 0.
        /// </summary>
        /// <param name="parameter">Evaluation context forwarded to child nodes.</param>
        /// <returns>The result of Mathf.SmoothStep(fromValue, toValue, tValue), or 0 if all three child nodes are null.</returns>
        public override float Calculate(object[] parameter)
        {
            if (_t == null && _from == null && _to == null)
            {
                return 0;
            }
            
            return Mathf.SmoothStep(
                _from.Calculate(parameter),
                _to.Calculate(parameter),
                _t.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// <summary>
            /// Formats the node as a SmoothStep expression.
            /// </summary>
            /// <returns>The equation in the form "SmoothStep(fromEq,toEq,tEq)"; uses "?" for any missing operand.</returns>
        public override string ToEquation() =>
            "SmoothStep(" 
            + (_from != null ? _from.ToEquation() : "?") + "," 
            + (_to != null ? _to.ToEquation() : "?") + "," 
            + (_t != null ? _t.ToEquation() : "?") + ")";
    }
}
