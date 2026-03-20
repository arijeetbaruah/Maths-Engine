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
        /// <summary>
        /// Computes a repeating ping-pong value between 0 and the configured length using the `_t` input node as the driving position.
        /// </summary>
        /// <param name="parameter">Evaluation arguments forwarded to `_t` and `_length` child nodes.</param>
        /// <returns>A float in the range [0, length] representing Mathf.PingPong(t, length); returns 0 if either `_t` or `_length` is null.</returns>
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
        /// <summary>
            /// Builds a textual equation representing this node as a PingPong expression.
            /// </summary>
            /// <returns>A string formatted as "PingPong(&lt;tEquation&gt;,&lt;lengthEquation&gt;)" where a "?" is used for any missing child node equation.</returns>
        public override string ToEquation() =>
            "PingPong(" 
            + (_t != null ? _t.ToEquation() : "?") + "," 
            + (_length != null ? _length.ToEquation() : "?") + ")";
    }
}
