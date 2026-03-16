using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Utility
{
    /// <summary>
    /// Returns Unity's frame delta time.
    /// </summary>
    /// <remarks>
    /// Equivalent to <see cref="Time.deltaTime"/>.
    /// Commonly used for frame-rate independent calculations.
    /// </remarks>
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
}
