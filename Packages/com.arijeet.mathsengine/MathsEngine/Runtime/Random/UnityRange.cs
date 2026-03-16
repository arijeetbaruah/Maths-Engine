using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Random
{
    /// <summary>
    /// Generates a random value within a specified range.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="UnityEngine.Random.Range(float,float)"/>.
    /// Each evaluation may return a different result.
    /// </remarks>
    [MathNodeCategory("Random")]
    public class UnityRange : BaseMathNode
    {
        /// <summary>
        /// Node producing the minimum value.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _min;

        /// <summary>
        /// Node producing the maximum value.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _max;

        /// <summary>
        /// Generates a random value between the evaluated min and max.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return UnityEngine.Random.Range(
                _min.Calculate(parameter),
                _max.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "Random(" + _min.ToEquation() + "," + _max.ToEquation() + ")";
    }
}
