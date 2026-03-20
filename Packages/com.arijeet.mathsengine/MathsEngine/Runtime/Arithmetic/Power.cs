using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Arithmetic
{
    /// <summary>
    /// Raises a value to the power of another value.
    /// </summary>
    /// <remarks>
    /// Uses Unity's Mathf.Pow internally.
    /// </remarks>
    [MathNodeCategory("Arithmetic")]
    public class Power : BaseMathNode
    {
        /// <summary>
        /// Base value.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _num1;

        /// <summary>
        /// Exponent value.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _num2;

        /// <summary>
        /// Calculates the exponentiation result.
        /// <summary>
        /// Calculates the value of the base node raised to the exponent node.
        /// </summary>
        /// <param name="parameter">Runtime parameters forwarded to child nodes' Calculate calls.</param>
        /// <returns>The computed power (base^exponent), or 0 if either child node is null.</returns>
        public override float Calculate(object[] parameter)
        {
            if (_num1 == null || _num2 == null)
            {
                return 0;
            }
            
            return Mathf.Pow(_num1.Calculate(parameter), _num2.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// <summary>
            /// Builds a parenthesized string representation of this power expression from its child nodes.
            /// </summary>
            /// <returns>A string in the form "(base ^ exponent)", where each operand is the child's equation or "?" if that child is null.</returns>
        public override string ToEquation() =>
            "(" + (_num1 != null ? _num1.ToEquation() : "?") + " ^ "
            + (_num2 != null ? _num2.ToEquation() : "?") + ")";
    }
}
