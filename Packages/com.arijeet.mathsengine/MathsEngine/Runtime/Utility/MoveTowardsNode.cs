using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Utility
{
    /// <summary>
    /// Gradually moves a value toward a target value.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.MoveTowards"/>.
    /// Useful for smoothing values such as velocity, health regeneration,
    /// or animation blending.
    /// </remarks>
    [MathNodeCategory("Utility")]
    public class MoveTowardsNode : BaseMathNode
    {
        /// <summary>
        /// Current value.
        /// </summary>
        [SerializeField, SerializeReference]
        private BaseMathNode _current;

        /// <summary>
        /// Target value.
        /// </summary>
        [SerializeField, SerializeReference]
        private BaseMathNode _target;

        /// <summary>
        /// Maximum allowed change.
        /// </summary>
        [SerializeField, SerializeReference]
        private BaseMathNode _maxDelta;

        /// <summary>
        /// Calculates the next value moving toward the target.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Mathf.MoveTowards(
                _current.Calculate(parameter),
                _target.Calculate(parameter),
                _maxDelta.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "MoveTowards(" + _current.ToEquation() + "," + _target.ToEquation() + "," + _maxDelta.ToEquation() + ")";
    }
}
