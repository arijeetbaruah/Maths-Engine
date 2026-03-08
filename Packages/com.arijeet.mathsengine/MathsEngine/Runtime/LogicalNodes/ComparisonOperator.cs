using UnityEngine;

namespace Baruah.MathsEngine.ComparisonOperators
{
    [System.Serializable]
    public abstract class ComparisonOperator
    {
        public virtual bool Check(float a, float b) => false;
        public abstract string Symbol { get; }
    }

    [System.Serializable]
    public class Greater : ComparisonOperator
    {
        public override bool Check(float a, float b)
        {
            return a > b;
        }

        public override string Symbol => ">";
    }
    
    [System.Serializable]
    public class Less : ComparisonOperator
    {
        public override bool Check(float a, float b)
        {
            return a < b;
        }
        
        public override string Symbol => "<";
    }
    
    [System.Serializable]
    public class GreaterOrEqual : ComparisonOperator
    {
        public override bool Check(float a, float b)
        {
            return a >= b;
        }
        
        public override string Symbol => ">=";
    }
    
    [System.Serializable]
    public class LessOrEqual : ComparisonOperator
    {
        public override bool Check(float a, float b)
        {
            return a <= b;
        }
        
        public override string Symbol => "<=";
    }
    
    [System.Serializable]
    public class Equal : ComparisonOperator
    {
        public override bool Check(float a, float b)
        {
            return a == b;
        }
        
        public override string Symbol => "==";
    }
    
    [System.Serializable]
    public class NotEqual : ComparisonOperator
    {
        public override bool Check(float a, float b)
        {
            return a != b;
        }
        
        public override string Symbol => "!=";
    }
    
    [System.Serializable]
    public class Approximately : ComparisonOperator
    {
        public float Tolerance = 0.01f;

        public override bool Check(float a, float b)
        {
            return Mathf.Abs(a - b) <= Tolerance;
        }
        
        public override string Symbol => "Approx";
    }
}
