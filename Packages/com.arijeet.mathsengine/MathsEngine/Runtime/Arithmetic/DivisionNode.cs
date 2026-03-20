using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Arithmetic
{
    /// <summary>
    /// A math node that divides one node by another.
    /// </summary>
    /// <remarks>
    /// The numerator is evaluated first, followed by the denominator.
    /// No explicit protection against division by zero is performed.
    /// </remarks>
    
    [MathNodeCategory("Arithmetic")]
    public class DivisionNode : BaseMathNode
    {
        /// <summary>
        /// The numerator node.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _numerator;

        /// <summary>
        /// The denominator node.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _denominator;

        /// <summary>
        /// Calculates the division result.
        /// <summary>
        /// Compute the value of the numerator node divided by the denominator node.
        /// </summary>
        /// <param name="parameter">Arguments forwarded to child nodes' Calculate methods.</param>
        /// <returns>The numerator's calculated value divided by the denominator's calculated value; returns 0 if either child node is null. If the denominator evaluates to zero, the result follows IEEE floating-point rules (Infinity or NaN).</returns>
        public override float Calculate(object[] parameter)
        {
            if (_numerator == null || _denominator == null)
            {
                return 0f;
            }
            
            return _numerator.Calculate(parameter) / _denominator.Calculate(parameter);
        }

        /// <summary>
        /// Returns the equation representation of the division.
        /// <summary>
            /// Formats this division node and its operands as "(numerator / denominator)"; uses "?" for any missing operand.
            /// </summary>
            /// <returns>The division expression string, e.g. "(a / b)" or "(? / b)".</returns>
        public override string ToEquation() =>
            "(" + (_numerator != null ? _numerator.ToEquation() : "?") + " / " +
            (_denominator != null ? _denominator.ToEquation() : "?") + ")";
    }
}
