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
        /// <summary>
        /// Computes the remainder of the first child node's value divided by the second child node's value.
        /// </summary>
        /// <returns>The remainder (first child's value % second child's value); `0f` if either child node is null.</returns>
        public override float Calculate(object[] parameter)
        {
            if (_num1 == null || _num2 == null)
            {
                return 0f;
            }
            
            return _num1.Calculate(parameter) % _num2.Calculate(parameter);
        }

        /// <summary>
        /// Returns the equation representation.
        /// <summary>
            /// Produces a parenthesized infix string representing the modulo operation between the two child nodes.
            /// </summary>
            /// <returns>A string in the form <c>(&lt;left&gt; % &lt;right&gt;)</c> where each side is the child's equation or <c>?</c> if that child is null.</returns>
        public override string ToEquation() =>
            "(" + (_num1 != null ? _num1.ToEquation() : "?") + " % "
            + (_num2 != null ? _num2.ToEquation() : "?") + ")";
    }
}
