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
        /// <returns>The sine of the input angle.</returns>
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
        /// </summary>
        public override string ToEquation() => "Sin(" + (_angle != null ? _angle.ToEquation() : "?") + ")";
    }
}
