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
        /// <summary>
        /// Computes the angle in radians of the 2D vector defined by the Y and X child nodes.
        /// </summary>
        /// <param name="parameter">Calculation parameters forwarded to the child nodes.</param>
        /// <returns>The angle in radians between the positive X axis and the point (x, y); `0` if either child node is null.</returns>
        public override float Calculate(object[] parameter)
        {
            if (_x == null || _y == null)
                return 0;
            
            return Mathf.Atan2(_y.Calculate(parameter), _x.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// <summary>
            /// Builds the equation string for this node's atan2 operation using its child nodes.
            /// </summary>
            /// <returns>A string formatted as "Atan2(&lt;yEquation or ?&gt; , &lt;xEquation or ?&gt;)" where "?" denotes a missing child node.</returns>
        public override string ToEquation() =>
            "Atan2(" + (_y != null ? _y.ToEquation() : "?") + " , " + (_x != null ? _x.ToEquation() : "?") + ")";
    }
}
