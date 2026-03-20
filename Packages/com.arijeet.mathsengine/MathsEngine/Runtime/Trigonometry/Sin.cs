using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Trigonometry
{
    /// <summary>
    /// Calculates the sine of an angle.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.Sin"/> internally.
    /// The input angle is expected to be in radians.
    /// </remarks>
    [MathNodeCategory("Trigonometry")]
    public class Sin : BaseMathNode
    {
        /// <summary>
        /// Node that produces the angle value in radians.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _angle;

        /// <summary>
        /// Calculates the sine of the evaluated angle.
        /// </summary>
        /// <param name="parameter">Runtime parameters passed through the formula evaluation.</param>
        /// <summary>
        /// Computes the sine of the angle produced by the nested angle node using the supplied runtime parameters.
        /// If the nested angle node is null, returns 0.
        /// </summary>
        /// <param name="parameter">Runtime parameters forwarded to the nested angle node's evaluation.</param>
        /// <returns>The sine of the evaluated angle, or 0 if the internal angle node is null.</returns>
        public override float Calculate(object[] parameter)
        {
            if (_angle == null)
            {
                return 0;
            }
            
            return Mathf.Sin(_angle.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// <summary>
/// Builds a human-readable equation string representing the sine of the angle node.
/// </summary>
/// <returns>A string in the form "Sin(X)" where X is the angle node's equation; uses "?" if the angle node is null.</returns>
        public override string ToEquation() => "Sin(" + (_angle != null ? _angle.ToEquation() : "?") + ")";
    }
}
