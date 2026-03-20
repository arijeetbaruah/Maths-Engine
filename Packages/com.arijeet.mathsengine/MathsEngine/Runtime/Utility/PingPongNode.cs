using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Utility
{
    /// <summary>
    /// Produces a repeating ping-pong value between 0 and a specified length.
    /// </summary>
    /// <remarks>
    /// Internally uses <see cref="Mathf.PingPong"/>.
    /// Useful for oscillating values such as procedural animations
    /// or looping gameplay effects.
    /// </remarks>
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
            if (_t == null || _length == null)
            {
                return 0f;
            }
            
            return Mathf.PingPong(_t.Calculate(parameter), _length.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "PingPong(" 
            + (_t != null ? _t.ToEquation() : "?") + "," 
            + (_length != null ? _length.ToEquation() : "?") + ")";
    }
}
