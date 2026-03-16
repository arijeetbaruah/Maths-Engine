using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Utility
{
    /// <summary>
    /// Returns Unity's fixed update timestep.
    /// </summary>
    /// <remarks>
    /// Equivalent to <see cref="Time.fixedDeltaTime"/>.
    /// Useful for physics-related calculations.
    /// </remarks>
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
}
