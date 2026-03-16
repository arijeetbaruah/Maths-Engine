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
        /// <returns>The value obtained from the animation curve.</returns>
        public override float Calculate(object[] parameter)
        {
            return _curve.Evaluate(_time.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation of the node.
        /// </summary>
        public override string ToEquation() => "AnimationCurve(" + _time.ToEquation() + ")";
    }
}
