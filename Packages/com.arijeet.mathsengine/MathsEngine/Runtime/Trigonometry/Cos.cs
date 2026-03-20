using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Trigonometry
{
    /// <summary>
    /// Calculates the cosine of an angle.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.Cos"/> internally.
    /// The input angle must be in radians.
    /// </remarks>
    [MathNodeCategory("Trigonometry")]
    public class Cos : BaseMathNode
    {
        /// <summary>
        /// Node that produces the angle value in radians.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _angle;

        /// <summary>
        /// Calculates the cosine of the evaluated angle.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            if (_angle ==null)
            {
                return 0;
            }
            
            return Mathf.Cos(_angle.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() => "Cos(" + (_angle != null ? _angle.ToEquation() : "?") + ")";
    }
}
