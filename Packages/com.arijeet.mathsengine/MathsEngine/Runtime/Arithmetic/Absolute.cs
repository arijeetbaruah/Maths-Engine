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
        /// <summary>
        /// Calculates the absolute value of the configured input math node.
        /// </summary>
        /// <param name="parameter">Runtime parameters forwarded to the input node's Calculate method.</param>
        /// <returns>The absolute value of the input node's evaluated result.</returns>
        public override float Calculate(object[] parameter)
        {
            return Mathf.Abs( _num != null ? _num.Calculate(parameter) : 0);
        }

        /// <summary>
        /// Returns the equation representation.
        /// <summary>
            /// Builds a string representation of the absolute-value expression.
            /// </summary>
            /// <returns>A string in the form "Abs(&lt;input-equation&gt;)" where the input is the wrapped node's equation or "?" if the input node is missing.</returns>
        public override string ToEquation() =>
            "Abs(" + (_num != null ? _num.ToEquation() : "?") + ")";
    }
}
