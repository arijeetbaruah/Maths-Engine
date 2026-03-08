using UnityEngine;

namespace Baruah.MathsEngine
{
    [System.Serializable]
    public class LogicalNode : BaseMathNode
    {
        [SerializeField]
        private ComparisonEntry[] _entries;

        [SerializeReference, SerializeField] private BaseMathNode True;
        [SerializeReference, SerializeField] private BaseMathNode False;
        
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

        private bool EvaluateEntry(ComparisonEntry entry, object[] parameter)
        {
            if (entry.Comparison == null)
                return false;

            float a = entry.A?.Calculate(parameter) ?? 0f;
            float b = entry.B?.Calculate(parameter) ?? 0f;

            return entry.Comparison.Check(a, b);
        }
    }
    
    [System.Serializable]
    public struct ComparisonEntry
    {
        [SerializeReference] public BaseMathNode A;
        [SerializeReference] public BaseMathNode B;

        [SerializeReference] public ComparisonOperator Comparison;

        [SerializeReference] public LogicalOperator NextLogical;
    }

    [System.Serializable]
    public abstract class LogicalOperator
    {
        public abstract bool Check(bool A, bool B);
        public abstract string Symbol { get; }
    }

    [System.Serializable]
    public class AndOperator : LogicalOperator
    {
        public override bool Check(bool A, bool B)
        {
            return A && B;
        }

        public override string Symbol => " AND ";
    }
    
    [System.Serializable]
    public class OrOperator : LogicalOperator
    {
        public override bool Check(bool A, bool B)
        {
            return A || B;
        }
        
        public override string Symbol => " OR ";
    }
    
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
