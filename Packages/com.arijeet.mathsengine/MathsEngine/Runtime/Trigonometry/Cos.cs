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
        /// <summary>
        /// Computes the cosine of the configured angle node evaluated in radians.
        /// </summary>
        /// <param name="parameter">Values forwarded to nested nodes during evaluation.</param>
        /// <returns>The cosine of the evaluated angle in radians; returns 0 if the angle node is null.</returns>
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
        /// <summary>
/// Gets the formula representation of this cosine node as "Cos(&lt;angle-equation&gt;)", using "?" when the angle node is null.
/// </summary>
/// <returns>The string expression "Cos(&lt;angle-equation&gt;)" where &lt;angle-equation&gt; is the inner node's equation or "?" if the inner node is null.</returns>
        public override string ToEquation() => "Cos(" + (_angle != null ? _angle.ToEquation() : "?") + ")";
    }
}
