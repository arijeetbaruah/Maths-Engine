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
        /// </summary>
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
        /// </summary>
        public override string ToEquation() =>
            "-(" + (_num != null ? _num.ToEquation() : "?") + ")";
    }
}
