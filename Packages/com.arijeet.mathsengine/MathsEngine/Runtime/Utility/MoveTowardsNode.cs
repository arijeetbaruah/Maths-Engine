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
        /// <summary>
        /// Moves the current value toward the target value by at most the specified maximum delta.
        /// </summary>
        /// <param name="parameter">Runtime parameters forwarded to the child nodes when evaluating current, target, and max delta.</param>
        /// <returns>The value moved from current toward target by at most maxDelta; returns 0f if any input node is null.</returns>
        public override float Calculate(object[] parameter)
        {
            if (_current == null || _target == null || _maxDelta == null)
            {
                return 0f;
            }
            
            return Mathf.MoveTowards(
                _current.Calculate(parameter),
                _target.Calculate(parameter),
                _maxDelta.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// <summary>
            /// Creates a string representation of the MoveTowards expression using child equations or "?" for missing operands.
            /// </summary>
            /// <returns>A string in the form MoveTowards(currentEquation,targetEquation,maxDeltaEquation); any missing operand is represented by "?"</returns>
        public override string ToEquation() =>
            "MoveTowards(" 
            + (_current != null ? _current.ToEquation() : "?") + "," 
            + (_target != null ? _target.ToEquation() : "?") + "," 
            + (_maxDelta != null ? _maxDelta.ToEquation() : "?") + ")";
    }
}
