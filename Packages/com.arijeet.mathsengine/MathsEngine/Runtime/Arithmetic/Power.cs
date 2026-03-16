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
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Mathf.Pow(_num1.Calculate(parameter), _num2.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "(" + _num1.ToEquation() + " ^ " + _num2.ToEquation() + ")";
    }
}
