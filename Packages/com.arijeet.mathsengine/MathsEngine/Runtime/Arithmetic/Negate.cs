using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Arithmetic
{
    /// <summary>
    /// Negates a numeric value.
    /// </summary>
    /// <remarks>
    /// Converts a value into its negative equivalent.
    /// </remarks>
    [MathNodeCategory("Arithmetic")]
    public class Negate : BaseMathNode
    {
        /// <summary>
        /// Input node whose value will be negated.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _num;

        /// <summary>
        /// Calculates the negated value.
        /// <summary>
        /// Negates the numeric result produced by the child math node.
        /// </summary>
        /// <param name="parameter">Evaluation parameters forwarded to the child node.</param>
        /// <returns>`0` if the child node is null; otherwise the child's result multiplied by -1.</returns>
        public override float Calculate(object[] parameter)
        {
            if (_num == null)
            {
                return 0;
            }
            
            return -_num.Calculate(parameter);
        }

        /// <summary>
        /// Returns the equation representation.
        /// <summary>
            /// Produces the equation string representing arithmetic negation of the input node.
            /// </summary>
            /// <returns>A string in the form "-(<input>)"; uses "?" inside the parentheses when the input node is null.</returns>
        public override string ToEquation() =>
            "-(" + (_num != null ? _num.ToEquation() : "?") + ")";
    }
}
