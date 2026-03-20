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
        /// <summary>
        /// Clamps the value produced by the child nodes to the evaluated minimum and maximum.
        /// </summary>
        /// <param name="parameter">Evaluation context passed to the child nodes.</param>
        /// <returns>The resulting float constrained between the evaluated min and max; returns 0f if any child node is missing.</returns>
        public override float Calculate(object[] parameter)
        {
            if (_value == null || _min == null || _max == null)
            {
                return 0f;
            }
            
            return Mathf.Clamp(
                _value.Calculate(parameter),
                _min.Calculate(parameter),
                _max.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// <summary>
                /// Formats this node as a Clamp expression.
                /// </summary>
                /// <returns>The equation string "Clamp(&lt;value&gt;,&lt;min&gt;,&lt;max&gt;)", where any missing child node is replaced with "?".</returns>
        public override string ToEquation() =>
            "Clamp(" 
                + (_value != null ? _value.ToEquation() : "?") + "," 
                + (_min != null ? _min.ToEquation() : "?") + "," 
                + (_max != null ? _max.ToEquation() : "?") + ")";
    }
}
