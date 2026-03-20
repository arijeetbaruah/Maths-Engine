using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Trigonometry
{
    /// <summary>
    /// Calculates the tangent of an angle.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.Tan"/>.
    /// The input angle should be in radians.
    /// </remarks>
    [MathNodeCategory("Trigonometry")]
    public class Tan : BaseMathNode
    {
        /// <summary>
        /// Node that produces the angle value in radians.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _angle;

        /// <summary>
        /// Calculates the tangent of the evaluated angle.
        /// <summary>
        /// Computes the tangent of the angle provided by the child node; the angle is interpreted in radians.
        /// </summary>
        /// <param name="parameter">Evaluation parameters passed to child nodes.</param>
        /// <returns>The tangent of the evaluated angle in radians, or 0 if the angle node is missing.</returns>
        public override float Calculate(object[] parameter)
        {
            if (_angle == null)
            {
                return 0;
            }

            return Mathf.Tan(_angle.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// <summary>
/// Produces the equation representation of this tangent node.
/// </summary>
/// <returns>The equation string in the form "Tan(x)" where x is the angle subnode's equation, or "?" if the angle node is null.</returns>
        public override string ToEquation() => "Tan(" + (_angle != null ? _angle.ToEquation() : "?") + ")";
    }
}
