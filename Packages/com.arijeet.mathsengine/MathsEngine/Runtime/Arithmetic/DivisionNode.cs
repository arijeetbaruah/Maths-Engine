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
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return _numerator.Calculate(parameter) / _denominator.Calculate(parameter);
        }

        /// <summary>
        /// Returns the equation representation of the division.
        /// </summary>
        public override string ToEquation() =>
            "(" + _numerator.ToEquation() + " / " + _denominator.ToEquation() + ")";
    }
}
