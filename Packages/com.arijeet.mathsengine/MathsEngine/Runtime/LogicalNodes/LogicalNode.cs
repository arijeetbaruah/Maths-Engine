using Baruah.MathsEngine.ComparisonOperators;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.LogicalOperation
{
    /// <summary>
    /// A math node that evaluates a chain of comparison expressions and returns one of two values.
    /// </summary>
    /// <remarks>
    /// Each <see cref="ComparisonEntry"/> evaluates a comparison between two math nodes.
    /// Entries can be chained together using logical operators such as AND, OR, or XOR.
    /// 
    /// After the comparison chain is evaluated, the node behaves like a ternary expression:
    /// 
    /// <code>
    /// condition ? True : False
    /// </code>
    /// 
    /// If the final result of the logical evaluation is true, the <see cref="True"/> node
    /// is evaluated and returned. Otherwise the <see cref="False"/> node is evaluated.
    /// </remarks>
    public class LogicalNode : BaseMathNode
    {
        /// <summary>
        /// Collection of comparison entries forming the logical condition chain.
        /// </summary>
        [SerializeField]
        private ComparisonEntry[] _entries;

        /// <summary>
        /// Node evaluated when the logical condition resolves to true.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode True;

        /// <summary>
        /// Node evaluated when the logical condition resolves to false.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode False;

        /// <summary>
        /// Evaluates the logical comparison chain and returns the appropriate result node.
        /// </summary>
        /// <param name="parameter">Runtime parameters passed to child nodes.</param>
        /// <returns>The calculated value from either the True or False branch.</returns>
        public override float Calculate(object[] parameter)
        {
            if (_entries == null || _entries.Length == 0)
                return False.Calculate(parameter);

            bool result = EvaluateEntry(_entries[0], parameter);

            for (int i = 1; i < _entries.Length; i++)
            {
                var previous = _entries[i - 1];

                if (previous.NextLogical == null)
                    break;

                bool nextValue = EvaluateEntry(_entries[i], parameter);

                result = previous.NextLogical.Check(result, nextValue);
            }

            return result ? True.Calculate(parameter) : False.Calculate(parameter);
        }

        /// <summary>
        /// Builds a parenthesized ternary equation string representing this logical node.
        /// </summary>
        /// <remarks>
        /// The generated equation follows this format:
        /// 
        /// <code>
        /// (A &gt; B AND C &lt; D ? TrueValue : FalseValue)
        /// </code>
        /// 
        /// Null nodes are represented as <c>0</c> and missing operators as <c>?</c>.
        /// </remarks>
        /// <returns>A human-readable equation representation of the logical node.</returns>
        public override string ToEquation()
        {
            if (_entries == null || _entries.Length == 0)
                return $"(0 ? {True?.ToEquation() ?? "0"} : {False?.ToEquation() ?? "0"})";

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("(");

            for (int i = 0; i < _entries.Length; i++)
            {
                var entry = _entries[i];

                string a = entry.A?.ToEquation() ?? "0";
                string b = entry.B?.ToEquation() ?? "0";
                string comp = entry.Comparison?.Symbol ?? "?";

                sb.Append($"{a} {comp} {b}");

                if (entry.NextLogical != null)
                {
                    sb.Append($" {entry.NextLogical.Symbol} ");
                }
            }

            sb.Append(")");

            string trueEq = True?.ToEquation() ?? "0";
            string falseEq = False?.ToEquation() ?? "0";

            return $"({sb} ? {trueEq} : {falseEq})";
        }

        /// <summary>
        /// Evaluates a single comparison entry.
        /// </summary>
        /// <param name="entry">The comparison entry containing operands and comparison operator.</param>
        /// <param name="parameter">Runtime parameters forwarded to child nodes.</param>
        /// <returns>
        /// True if the comparison evaluates successfully; otherwise false.
        /// </returns>
        private bool EvaluateEntry(ComparisonEntry entry, object[] parameter)
        {
            if (entry.Comparison == null)
                return false;

            float a = entry.A?.Calculate(parameter) ?? 0f;
            float b = entry.B?.Calculate(parameter) ?? 0f;

            return entry.Comparison.Check(a, b);
        }
    }

    /// <summary>
    /// Represents a single comparison operation within a logical chain.
    /// </summary>
    /// <remarks>
    /// Each entry compares two math nodes using a <see cref="ComparisonOperator"/>.
    /// The result can optionally be combined with the next entry using a
    /// <see cref="LogicalOperator"/>.
    /// </remarks>
    [System.Serializable]
    public struct ComparisonEntry
    {
        /// <summary>
        /// Left-hand operand node.
        /// </summary>
        [SerializeReference]
        public BaseMathNode A;

        /// <summary>
        /// Right-hand operand node.
        /// </summary>
        [SerializeReference]
        public BaseMathNode B;

        /// <summary>
        /// Comparison operator applied to the operands.
        /// </summary>
        [SerializeReference]
        public ComparisonOperator Comparison;

        /// <summary>
        /// Logical operator used to combine this entry with the next one.
        /// </summary>
        [SerializeReference]
        public LogicalOperator NextLogical;
    }

    /// <summary>
    /// Base class for logical operators used to combine boolean results.
    /// </summary>
    [System.Serializable]
    public abstract class LogicalOperator
    {
        /// <summary>
        /// Combines two boolean values using the logical operation.
        /// </summary>
        public abstract bool Check(bool A, bool B);

        /// <summary>
        /// Symbol representing the logical operator.
        /// </summary>
        public abstract string Symbol { get; }
    }

    /// <summary>
    /// Logical AND operator.
    /// </summary>
    /// <remarks>
    /// Returns true only if both operands are true.
    /// </remarks>
    [System.Serializable]
    public class AndOperator : LogicalOperator
    {
        public override bool Check(bool A, bool B)
        {
            return A && B;
        }

        public override string Symbol => " AND ";
    }

    /// <summary>
    /// Logical OR operator.
    /// </summary>
    /// <remarks>
    /// Returns true if at least one operand is true.
    /// </remarks>
    [System.Serializable]
    public class OrOperator : LogicalOperator
    {
        public override bool Check(bool A, bool B)
        {
            return A || B;
        }

        public override string Symbol => " OR ";
    }

    /// <summary>
    /// Logical XOR (exclusive OR) operator.
    /// </summary>
    /// <remarks>
    /// Returns true if exactly one operand is true.
    /// </remarks>
    [System.Serializable]
    public class XorOperator : LogicalOperator
    {
        public override bool Check(bool A, bool B)
        {
            return A ^ B;
        }

        public override string Symbol => " XOR ";
    }
}
