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
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Mathf.Tan(_angle.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() => "Tan(" + _angle.ToEquation() + ")";
    }
}
