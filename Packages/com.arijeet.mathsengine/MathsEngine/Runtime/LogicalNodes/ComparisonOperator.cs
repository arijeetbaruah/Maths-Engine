using UnityEngine;

namespace Baruah.MathsEngine
{
    [System.Serializable]
    public abstract class ComparisonOperator
    {
        public virtual bool Check(float a, float b) => false;
    }

    [System.Serializable]
    public class Greater : ComparisonOperator
    {
        public override bool Check(float a, float b)
        {
            return a > b;
        }
    }
    
    [System.Serializable]
    public class Less : ComparisonOperator
    {
        public override bool Check(float a, float b)
        {
            return a < b;
        }
    }
    
    [System.Serializable]
    public class GreaterOrEqual : ComparisonOperator
    {
        public override bool Check(float a, float b)
        {
            return a >= b;
        }
    }
    
    [System.Serializable]
    public class LessOrEqual : ComparisonOperator
    {
        public override bool Check(float a, float b)
        {
            return a <= b;
        }
    }
    
    [System.Serializable]
    public class Equal : ComparisonOperator
    {
        public override bool Check(float a, float b)
        {
            return a == b;
        }
    }
    
    [System.Serializable]
    public class NotEqual : ComparisonOperator
    {
        public override bool Check(float a, float b)
        {
            return a != b;
        }
    }
    
    [System.Serializable]
    public class Approximately : ComparisonOperator
    {
        public float Tolerance = 0.01f;

        public override bool Check(float a, float b)
        {
            return Mathf.Abs(a - b) <= Tolerance;
        }
    }
}
