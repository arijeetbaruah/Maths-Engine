using UnityEngine;

namespace Baruah.MathsEngine.ComparisonOperators
{
    /// <summary>
    /// Base class for all comparison operators used in the math engine.
    /// </summary>
    /// <remarks>
    /// Comparison operators evaluate two floating point values and return
    /// a boolean result indicating whether the comparison condition is met.
    /// These operators are typically used by logical or conditional nodes
    /// inside the formula graph.
    /// </remarks>
    [System.Serializable]
    public abstract class ComparisonOperator
    {
        /// <summary>
        /// Evaluates the comparison between two values.
        /// </summary>
        /// <param name="a">Left-hand operand.</param>
        /// <param name="b">Right-hand operand.</param>
        /// <returns>True if the comparison condition is satisfied.</returns>
        public virtual bool Check(float a, float b) => false;

        /// <summary>
        /// Symbol representing the operator in equation form.
        /// </summary>
        public abstract string Symbol { get; }
    }


    /// <summary>
    /// Checks whether the first value is greater than the second.
    /// </summary>
    [System.Serializable]
    public class Greater : ComparisonOperator
    {
        /// <summary>
        /// Returns true if <paramref name="a"/> is greater than <paramref name="b"/>.
        /// </summary>
        public override bool Check(float a, float b)
        {
            return a > b;
        }

        /// <summary>
        /// Operator symbol used in equations.
        /// </summary>
        public override string Symbol => ">";
    }


    /// <summary>
    /// Checks whether the first value is less than the second.
    /// </summary>
    [System.Serializable]
    public class Less : ComparisonOperator
    {
        /// <summary>
        /// Returns true if <paramref name="a"/> is less than <paramref name="b"/>.
        /// </summary>
        public override bool Check(float a, float b)
        {
            return a < b;
        }

        /// <summary>
        /// Operator symbol used in equations.
        /// </summary>
        public override string Symbol => "<";
    }


    /// <summary>
    /// Checks whether the first value is greater than or equal to the second.
    /// </summary>
    [System.Serializable]
    public class GreaterOrEqual : ComparisonOperator
    {
        /// <summary>
        /// Returns true if <paramref name="a"/> is greater than or equal to <paramref name="b"/>.
        /// </summary>
        public override bool Check(float a, float b)
        {
            return a >= b;
        }

        /// <summary>
        /// Operator symbol used in equations.
        /// </summary>
        public override string Symbol => ">=";
    }


    /// <summary>
    /// Checks whether the first value is less than or equal to the second.
    /// </summary>
    [System.Serializable]
    public class LessOrEqual : ComparisonOperator
    {
        /// <summary>
        /// Returns true if <paramref name="a"/> is less than or equal to <paramref name="b"/>.
        /// </summary>
        public override bool Check(float a, float b)
        {
            return a <= b;
        }

        /// <summary>
        /// Operator symbol used in equations.
        /// </summary>
        public override string Symbol => "<=";
    }


    /// <summary>
    /// Checks whether two values are exactly equal.
    /// </summary>
    /// <remarks>
    /// Floating point equality comparisons can be unreliable due to precision
    /// limitations. For approximate comparisons consider using
    /// <see cref="Approximately"/>.
    /// </remarks>
    [System.Serializable]
    public class Equal : ComparisonOperator
    {
        /// <summary>
        /// Returns true if the values are exactly equal.
        /// </summary>
        public override bool Check(float a, float b)
        {
            return a == b;
        }

        /// <summary>
        /// Operator symbol used in equations.
        /// </summary>
        public override string Symbol => "==";
    }


    /// <summary>
    /// Checks whether two values are not equal.
    /// </summary>
    [System.Serializable]
    public class NotEqual : ComparisonOperator
    {
        /// <summary>
        /// Returns true if the values are different.
        /// </summary>
        public override bool Check(float a, float b)
        {
            return a != b;
        }

        /// <summary>
        /// Operator symbol used in equations.
        /// </summary>
        public override string Symbol => "!=";
    }


    /// <summary>
    /// Checks whether two values are approximately equal within a tolerance.
    /// </summary>
    /// <remarks>
    /// Floating point calculations often introduce small precision errors.
    /// This operator considers two numbers equal if the absolute difference
    /// between them is less than or equal to the specified tolerance.
    /// </remarks>
    [System.Serializable]
    public class Approximately : ComparisonOperator
    {
        /// <summary>
        /// Allowed difference between the two values.
        /// </summary>
        public float Tolerance = 0.01f;

        /// <summary>
        /// Returns true if the difference between the two values is within tolerance.
        /// </summary>
        public override bool Check(float a, float b)
        {
            return Mathf.Abs(a - b) <= Tolerance;
        }

        /// <summary>
        /// Operator symbol used in equations.
        /// </summary>
        public override string Symbol => "Approx";
    }
}
