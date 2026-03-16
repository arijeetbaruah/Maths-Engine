using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Utility.Range
{
    /// <summary>
    /// Linearly interpolates between two values.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.Lerp"/>.
    /// The interpolation parameter <c>t</c> typically ranges from 0 to 1.
    /// </remarks>
    [MathNodeCategory("Utility/Range")]
    public class Lerp : BaseMathNode
    {
        /// <summary>
        /// Starting value.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _a;

        /// <summary>
        /// Ending value.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _b;

        /// <summary>
        /// Interpolation parameter.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _t;

        /// <summary>
        /// Calculates the interpolated value.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Mathf.Lerp(
                _a.Calculate(parameter),
                _b.Calculate(parameter),
                _t.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "Lerp(" + _a.ToEquation() + "," + _b.ToEquation() + "," + _t.ToEquation() + ")";
    }
}
