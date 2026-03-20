using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Utility
{
    /// <summary>
    /// Evaluates a Unity <see cref="AnimationCurve"/> using the value produced by a time node.
    /// </summary>
    /// <remarks>
    /// This node is useful for creating designer-friendly curves that control
    /// gameplay values such as damage scaling, movement acceleration,
    /// or animation blending.
    /// </remarks>
    [MathNodeCategory("Utility")]
    public class AnimationCurveNode : BaseMathNode
    {
        /// <summary>
        /// The animation curve used to transform the input value.
        /// </summary>
        [SerializeField]
        private AnimationCurve _curve;

        /// <summary>
        /// Node used to generate the input value (time) for the curve.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _time;

        /// <summary>
        /// Evaluates the animation curve using the calculated input time.
        /// </summary>
        /// <param name="parameter">Runtime parameters passed through the formula evaluation.</param>
        /// <summary>
        /// Evaluates the configured AnimationCurve at the time produced by the nested time node.
        /// </summary>
        /// <returns>`0f` if the configured curve or time node is null; otherwise the curve's value at the time produced by the time node.</returns>
        public override float Calculate(object[] parameter)
        {
            if (_curve == null || _time == null)
            {
                return 0f;
            }
            
            return _curve.Evaluate(_time.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation of the node.
        /// <summary>
/// Produces the equation string for this animation-curve node, including its time sub-expression.
/// </summary>
/// <returns>The equation in the form "AnimationCurve(&lt;time&gt;)", where &lt;time&gt; is the time sub-expression produced by the child node or "?" if the time node is missing.</returns>
        public override string ToEquation() => "AnimationCurve(" +  (_time != null ? _time.ToEquation() : "?") + ")";
    }
}
