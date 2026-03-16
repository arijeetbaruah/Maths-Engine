using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Utility.Range
{
    /// <summary>
    /// Restricts a value so it stays within a specified range.
    /// </summary>
    /// <remarks>
    /// Internally uses <see cref="Clamp"/>.
    /// If the value is less than the minimum it returns the minimum.
    /// If the value is greater than the maximum it returns the maximum.
    /// Otherwise the value is returned unchanged.
    /// </remarks>
    [MathNodeCategory("Utility/Range")]
    public class Clamp : BaseMathNode
    {
        /// <summary>
        /// Node that produces the value to be clamped.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _value;

        /// <summary>
        /// Node that defines the minimum allowed value.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _min;

        /// <summary>
        /// Node that defines the maximum allowed value.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _max;

        /// <summary>
        /// Calculates the clamped value.
        /// </summary>
        /// <param name="parameter">Runtime parameters passed through the formula evaluation.</param>
        /// <returns>The clamped result.</returns>
        public override float Calculate(object[] parameter)
        {
            return Mathf.Clamp(
                _value.Calculate(parameter),
                _min.Calculate(parameter),
                _max.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "Clamp(" + _value.ToEquation() + "," + _min.ToEquation() + "," + _max.ToEquation() + ")";
    }
}
