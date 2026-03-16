using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Arithmetic
{
    /// <summary>
    /// Calculates the modulo (remainder) of two values.
    /// </summary>
    /// <remarks>
    /// Returns the remainder after dividing the first number by the second.
    /// </remarks>
    [MathNodeCategory("Arithmetic")]
    public class Modulo : BaseMathNode
    {
        /// <summary>
        /// Dividend node.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _num1;

        /// <summary>
        /// Divisor node.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _num2;

        /// <summary>
        /// Calculates the modulo result.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return _num1.Calculate(parameter) % _num2.Calculate(parameter);
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "(" + _num1.ToEquation() + " % " + _num2.ToEquation() + ")";
    }
}
