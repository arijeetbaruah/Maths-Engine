using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Trigonometry
{
    /// <summary>
    /// Constant value used to convert degrees to radians.
    /// </summary>
    /// <remarks>
    /// Equivalent to <see cref="Mathf.Deg2Rad"/>.
    /// Multiply a degree value by this constant to convert it to radians.
    /// </remarks>
    [MathNodeCategory("Constants")]
    public class Deg2Rad : BaseMathNode
    {
        /// <summary>
        /// Returns the degree-to-radian conversion constant.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Mathf.Deg2Rad;
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() => "Deg2Rad";
    }
}
