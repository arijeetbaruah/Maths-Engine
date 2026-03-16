using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Arithmetic
{
    /// <summary>
    /// Returns the absolute value of a number.
    /// </summary>
    /// <remarks>
    /// Converts negative numbers into their positive equivalent.
    /// </remarks>
    [MathNodeCategory("Arithmetic")]
    public class Absolute : BaseMathNode
    {
        /// <summary>
        /// Input node whose value will be converted to absolute.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _num;

        /// <summary>
        /// Calculates the absolute value.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Mathf.Abs(_num.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "Abs(" + _num.ToEquation() + ")";
    }
}
