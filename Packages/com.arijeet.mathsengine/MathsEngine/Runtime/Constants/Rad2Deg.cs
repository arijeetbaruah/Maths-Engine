using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Trigonometry
{
    /// <summary>
    /// Constant value used to convert radians to degrees.
    /// </summary>
    /// <remarks>
    /// Equivalent to <see cref="Mathf.Rad2Deg"/>.
    /// Multiply a radian value by this constant to convert it to degrees.
    /// </remarks>
    [MathNodeCategory("Constants")]
    public class Rad2Deg : BaseMathNode
    {
        /// <summary>
        /// Returns the radian-to-degree conversion constant.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Mathf.Rad2Deg;
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() => "Rad2Deg";
    }
}
