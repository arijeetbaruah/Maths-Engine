using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.GameOriented
{
    /// <summary>
    /// Evaluates a Unity <see cref="AnimationCurve"/> using the value produced by a time node.
    /// </summary>
    /// <remarks>
    /// This node is useful for creating designer-friendly curves that control
    /// gameplay values such as damage scaling, movement acceleration,
    /// or animation blending.
    /// </remarks>
    [System.Serializable]
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


    /// <summary>
    /// Returns the current Unity runtime time.
    /// </summary>
    /// <remarks>
    /// Equivalent to <see cref="Time.time"/>.
    /// Useful for time-based procedural formulas.
    /// </remarks>
    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class TimeNode : BaseMathNode
    {
        /// <summary>
        /// Returns the current elapsed time since the start of the game.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Time.time;
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() => "Time";
    }


    /// <summary>
    /// Returns Unity's frame delta time.
    /// </summary>
    /// <remarks>
    /// Equivalent to <see cref="Time.deltaTime"/>.
    /// Commonly used for frame-rate independent calculations.
    /// </remarks>
    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class DeltaTimeNode : BaseMathNode
    {
        /// <summary>
        /// Returns the time elapsed since the last frame.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Time.deltaTime;
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() => "DeltaTime";
    }


    /// <summary>
    /// Returns Unity's fixed update timestep.
    /// </summary>
    /// <remarks>
    /// Equivalent to <see cref="Time.fixedDeltaTime"/>.
    /// Useful for physics-related calculations.
    /// </remarks>
    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class FixedDeltaTimeNode : BaseMathNode
    {
        /// <summary>
        /// Returns the fixed physics timestep value.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Time.fixedDeltaTime;
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() => "FixedDeltaTime";
    }


    /// <summary>
    /// Produces a repeating ping-pong value between 0 and a specified length.
    /// </summary>
    /// <remarks>
    /// Internally uses <see cref="Mathf.PingPong"/>.
    /// Useful for oscillating values such as procedural animations
    /// or looping gameplay effects.
    /// </remarks>
    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class PingPongNode : BaseMathNode
    {
        /// <summary>
        /// Input value controlling the ping-pong progression.
        /// </summary>
        [SerializeField, SerializeReference]
        private BaseMathNode _t;

        /// <summary>
        /// Maximum value of the ping-pong range.
        /// </summary>
        [SerializeField, SerializeReference]
        private BaseMathNode _length;

        /// <summary>
        /// Calculates the ping-pong oscillation value.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Mathf.PingPong(_t.Calculate(parameter), _length.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "PingPong(" + _t.ToEquation() + "," + _length.ToEquation() + ")";
    }


    /// <summary>
    /// Performs smooth interpolation between two values.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.SmoothStep"/> to interpolate between
    /// the start and end values with smooth easing.
    /// </remarks>
    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class SmoothStepNode : BaseMathNode
    {
        /// <summary>
        /// Starting value.
        /// </summary>
        [SerializeField, SerializeReference]
        private BaseMathNode _from;

        /// <summary>
        /// Ending value.
        /// </summary>
        [SerializeField, SerializeReference]
        private BaseMathNode _to;

        /// <summary>
        /// Interpolation parameter.
        /// </summary>
        [SerializeField, SerializeReference]
        private BaseMathNode _t;

        /// <summary>
        /// Calculates the smooth interpolation result.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Mathf.SmoothStep(
                _from.Calculate(parameter),
                _to.Calculate(parameter),
                _t.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "SmoothStep(" + _from.ToEquation() + "," + _to.ToEquation() + "," + _t.ToEquation() + ")";
    }


    /// <summary>
    /// Gradually moves a value toward a target value.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.MoveTowards"/>.
    /// Useful for smoothing values such as velocity, health regeneration,
    /// or animation blending.
    /// </remarks>
    [System.Serializable]
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


    /// <summary>
    /// Returns the smaller of two values.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.Min"/>.
    /// </remarks>
    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class MinNode : BaseMathNode
    {
        /// <summary>
        /// First value.
        /// </summary>
        [SerializeField, SerializeReference]
        private BaseMathNode _a;

        /// <summary>
        /// Second value.
        /// </summary>
        [SerializeField, SerializeReference]
        private BaseMathNode _b;

        /// <summary>
        /// Calculates the minimum value.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Mathf.Min(_a.Calculate(parameter), _b.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "Min(" + _a.ToEquation() + "," + _b.ToEquation() + ")";
    }


    /// <summary>
    /// Returns the larger of two values.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.Max"/>.
    /// </remarks>
    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class MaxNode : BaseMathNode
    {
        /// <summary>
        /// First value.
        /// </summary>
        [SerializeField, SerializeReference]
        private BaseMathNode _a;

        /// <summary>
        /// Second value.
        /// </summary>
        [SerializeField, SerializeReference]
        private BaseMathNode _b;

        /// <summary>
        /// Calculates the maximum value.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Mathf.Max(_a.Calculate(parameter), _b.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "Max(" + _a.ToEquation() + "," + _b.ToEquation() + ")";
    }
}
