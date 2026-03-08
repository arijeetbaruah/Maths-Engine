using System.Linq;
using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Arithmetic
{
    /// <summary>
    /// A math node that sums the results of multiple child nodes.
    /// </summary>
    /// <remarks>
    /// Each value node is evaluated and the results are added together.
    /// This node supports any number of inputs.
    /// </remarks>
    [System.Serializable]
    [MathNodeCategory("Arithmetic")]
    public class AdditionNode : BaseMathNode
    {
        /// <summary>
        /// The nodes whose results will be added together.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode[] _values;

        /// <summary>
        /// Calculates the sum of all child nodes.
        /// </summary>
        /// <param name="parameter">Runtime parameters passed to child nodes.</param>
        /// <returns>The sum of all evaluated nodes.</returns>
        public override float Calculate(object[] parameter)
        {
            float ret = 0;
            foreach (var val in _values)
            {
                ret += val.Calculate(parameter);
            }

            return ret;
        }

        /// <summary>
        /// Returns the equation representation of this node.
        /// </summary>
        public override string ToEquation() =>
            "(" + string.Join(" + ", _values.Select(v => v == null ? "?" : v.ToEquation())) + ")";
    }


    /// <summary>
    /// A math node that subtracts multiple values sequentially.
    /// </summary>
    /// <remarks>
    /// The first node acts as the starting value and all subsequent
    /// nodes are subtracted from it.
    /// </remarks>
    [System.Serializable]
    [MathNodeCategory("Arithmetic")]
    public class SubtractionNode : BaseMathNode
    {
        /// <summary>
        /// The nodes used for subtraction.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode[] _values;

        /// <summary>
        /// Calculates the subtraction chain.
        /// </summary>
        /// <param name="parameter">Runtime parameters passed to child nodes.</param>
        /// <returns>The resulting value after sequential subtraction.</returns>
        public override float Calculate(object[] parameter)
        {
            float ret = _values[0].Calculate(parameter);

            for (int index = 1; index < _values.Length; index++)
            {
                ret -= _values[index].Calculate(parameter);
            }

            return ret;
        }

        /// <summary>
        /// Returns the equation representation of the subtraction.
        /// </summary>
        public override string ToEquation() =>
            "(" + string.Join(" - ", _values.Select(v => v == null ? "?" : v.ToEquation())) + ")";
    }


    /// <summary>
    /// A math node that multiplies multiple child nodes together.
    /// </summary>
    /// <remarks>
    /// If any node evaluates to zero the calculation exits early
    /// since the result must be zero.
    /// </remarks>
    [System.Serializable]
    [MathNodeCategory("Arithmetic")]
    public class MultiplicationNode : BaseMathNode
    {
        /// <summary>
        /// Nodes whose values will be multiplied.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode[] _values;

        /// <summary>
        /// Calculates the product of all child nodes.
        /// </summary>
        /// <param name="parameter">Runtime parameters passed to child nodes.</param>
        /// <returns>The multiplication result.</returns>
        public override float Calculate(object[] parameter)
        {
            float ret = 1;

            foreach (var val in _values)
            {
                ret *= val.Calculate(parameter);

                if (ret == 0)
                {
                    return 0;
                }
            }

            return ret;
        }

        /// <summary>
        /// Returns the equation representation of the multiplication.
        /// </summary>
        public override string ToEquation() =>
            "(" + string.Join(" * ", _values.Select(v => v == null ? "?" : v.ToEquation())) + ")";
    }


    /// <summary>
    /// A math node that divides one node by another.
    /// </summary>
    /// <remarks>
    /// The numerator is evaluated first, followed by the denominator.
    /// No explicit protection against division by zero is performed.
    /// </remarks>
    [System.Serializable]
    [MathNodeCategory("Arithmetic")]
    public class DivisionNode : BaseMathNode
    {
        /// <summary>
        /// The numerator node.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _numerator;

        /// <summary>
        /// The denominator node.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _denominator;

        /// <summary>
        /// Calculates the division result.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return _numerator.Calculate(parameter) / _denominator.Calculate(parameter);
        }

        /// <summary>
        /// Returns the equation representation of the division.
        /// </summary>
        public override string ToEquation() =>
            "(" + _numerator.ToEquation() + " / " + _denominator.ToEquation() + ")";
    }


    /// <summary>
    /// A constant value node.
    /// </summary>
    /// <remarks>
    /// This node always returns the same value regardless of input parameters.
    /// Useful for defining numeric constants in formulas.
    /// </remarks>
    [System.Serializable]
    [MathNodeCategory("Constants")]
    public class ConstantNode : BaseMathNode
    {
        /// <summary>
        /// The constant value returned by this node.
        /// </summary>
        [SerializeField]
        private float _value;

        /// <summary>
        /// Returns the constant value.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return _value;
        }

        /// <summary>
        /// Returns the equation representation of the constant.
        /// </summary>
        public override string ToEquation() => _value.ToString();
    }


    /// <summary>
    /// Calculates the modulo (remainder) of two values.
    /// </summary>
    /// <remarks>
    /// Returns the remainder after dividing the first number by the second.
    /// </remarks>
    [System.Serializable]
    [MathNodeCategory("Arithmetic")]
    public class Modulo : BaseMathNode
    {
        /// <summary>
        /// Dividend node.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _num1;

        /// <summary>
        /// Divisor node.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _num2;

        /// <summary>
        /// Calculates the modulo result.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return _num1.Calculate(parameter) % _num2.Calculate(parameter);
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "(" + _num1.ToEquation() + " % " + _num2.ToEquation() + ")";
    }


    /// <summary>
    /// Raises a value to the power of another value.
    /// </summary>
    /// <remarks>
    /// Uses Unity's Mathf.Pow internally.
    /// </remarks>
    [System.Serializable]
    [MathNodeCategory("Arithmetic")]
    public class Power : BaseMathNode
    {
        /// <summary>
        /// Base value.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _num1;

        /// <summary>
        /// Exponent value.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _num2;

        /// <summary>
        /// Calculates the exponentiation result.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Mathf.Pow(_num1.Calculate(parameter), _num2.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "(" + _num1.ToEquation() + " ^ " + _num2.ToEquation() + ")";
    }


    /// <summary>
    /// Returns the absolute value of a number.
    /// </summary>
    /// <remarks>
    /// Converts negative numbers into their positive equivalent.
    /// </remarks>
    [System.Serializable]
    [MathNodeCategory("Arithmetic")]
    public class Absolute : BaseMathNode
    {
        /// <summary>
        /// Input node whose value will be converted to absolute.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _num;

        /// <summary>
        /// Calculates the absolute value.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Mathf.Abs(_num.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "Abs(" + _num.ToEquation() + ")";
    }


    /// <summary>
    /// Negates a numeric value.
    /// </summary>
    /// <remarks>
    /// Converts a value into its negative equivalent.
    /// </remarks>
    [System.Serializable]
    [MathNodeCategory("Arithmetic")]
    public class Negate : BaseMathNode
    {
        /// <summary>
        /// Input node whose value will be negated.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _num;

        /// <summary>
        /// Calculates the negated value.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return -_num.Calculate(parameter);
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "-(" + _num.ToEquation() + ")";
    }
}
