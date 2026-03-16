using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Utility.Range
{
    /// <summary>
    /// Calculates the interpolation factor between two values.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.InverseLerp"/>.
    /// Determines where a value lies between two endpoints.
    /// </remarks>
    [MathNodeCategory("Utility")]
    public class InverseLerp : BaseMathNode
    {
        /// <summary>
        /// Lower bound of the range.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _a;

        /// <summary>
        /// Upper bound of the range.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _b;

        /// <summary>
        /// Value whose relative position is calculated.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _t;

        /// <summary>
        /// Calculates the normalized interpolation factor.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Mathf.InverseLerp(
                _a.Calculate(parameter),
                _b.Calculate(parameter),
                _t.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "InverseLerp(" + _a.ToEquation() + "," + _b.ToEquation() + "," + _t.ToEquation() + ")";
    }
}
