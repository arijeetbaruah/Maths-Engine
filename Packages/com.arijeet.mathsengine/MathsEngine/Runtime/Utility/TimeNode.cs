using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Utility
{
    /// <summary>
    /// Returns the current Unity runtime time.
    /// </summary>
    /// <remarks>
    /// Equivalent to <see cref="Time.time"/>.
    /// Useful for time-based procedural formulas.
    /// </remarks>
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
}
