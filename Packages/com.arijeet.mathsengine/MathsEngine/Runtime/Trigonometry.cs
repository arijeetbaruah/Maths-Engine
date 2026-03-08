using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Trigonometry
{
    /// <summary>
    /// Calculates the sine of an angle.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.Sin"/> internally.
    /// The input angle is expected to be in radians.
    /// </remarks>
    [System.Serializable]
    [MathNodeCategory("Trigonometry")]
    public class Sin : BaseMathNode
    {
        /// <summary>
        /// Node that produces the angle value in radians.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _angle;

        /// <summary>
        /// Calculates the sine of the evaluated angle.
        /// </summary>
        /// <param name="parameter">Runtime parameters passed through the formula evaluation.</param>
        /// <returns>The sine of the input angle.</returns>
        public override float Calculate(object[] parameter)
        {
            return Mathf.Sin(_angle.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() => "Sin(" + _angle.ToEquation() + ")";
    }


    /// <summary>
    /// Calculates the cosine of an angle.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.Cos"/> internally.
    /// The input angle must be in radians.
    /// </remarks>
    [System.Serializable]
    [MathNodeCategory("Trigonometry")]
    public class Cos : BaseMathNode
    {
        /// <summary>
        /// Node that produces the angle value in radians.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _angle;

        /// <summary>
        /// Calculates the cosine of the evaluated angle.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Mathf.Cos(_angle.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() => "Cos(" + _angle.ToEquation() + ")";
    }


    /// <summary>
    /// Calculates the tangent of an angle.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.Tan"/>.
    /// The input angle should be in radians.
    /// </remarks>
    [System.Serializable]
    [MathNodeCategory("Trigonometry")]
    public class Tan : BaseMathNode
    {
        /// <summary>
        /// Node that produces the angle value in radians.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _angle;

        /// <summary>
        /// Calculates the tangent of the evaluated angle.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Mathf.Tan(_angle.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() => "Tan(" + _angle.ToEquation() + ")";
    }


    /// <summary>
    /// Calculates the angle from a 2D vector using the Y and X components.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.Atan2"/>.
    /// The result is returned in radians.
    /// This node is commonly used to calculate directions or rotation angles.
    /// </remarks>
    [System.Serializable]
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
            return Mathf.Atan2(_y.Calculate(parameter), _x.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "Atan2(" + _y.ToEquation() + " , " + _x.ToEquation() + ")";
    }


    /// <summary>
    /// Constant value used to convert degrees to radians.
    /// </summary>
    /// <remarks>
    /// Equivalent to <see cref="Mathf.Deg2Rad"/>.
    /// Multiply a degree value by this constant to convert it to radians.
    /// </remarks>
    [System.Serializable]
    [MathNodeCategory("Constants")]
    public class Deg2Rad : BaseMathNode
    {
        /// <summary>
        /// Returns the degree-to-radian conversion constant.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Mathf.Deg2Rad;
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() => "Deg2Rad";
    }


    /// <summary>
    /// Constant value used to convert radians to degrees.
    /// </summary>
    /// <remarks>
    /// Equivalent to <see cref="Mathf.Rad2Deg"/>.
    /// Multiply a radian value by this constant to convert it to degrees.
    /// </remarks>
    [System.Serializable]
    [MathNodeCategory("Constants")]
    public class Rad2Deg : BaseMathNode
    {
        /// <summary>
        /// Returns the radian-to-degree conversion constant.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Mathf.Rad2Deg;
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() => "Rad2Deg";
    }
}
