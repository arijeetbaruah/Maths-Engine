using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Trigonometry
{
    /// <summary>
    /// Calculates the angle from a 2D vector using the Y and X components.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.Atan2"/>.
    /// The result is returned in radians.
    /// This node is commonly used to calculate directions or rotation angles.
    /// </remarks>
    [MathNodeCategory("Trigonometry")]
    public class Atan2 : BaseMathNode
    {
        /// <summary>
        /// Node representing the Y coordinate.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _y;

        /// <summary>
        /// Node representing the X coordinate.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _x;

        /// <summary>
        /// Calculates the angle between the positive X-axis and the vector (x, y).
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            if (_x == null || _y == null)
                return 0;
            
            return Mathf.Atan2(_y.Calculate(parameter), _x.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "Atan2(" + (_y != null ? _y.ToEquation() : "?") + " , " + (_x != null ? _x.ToEquation() : "?") + ")";
    }
}
