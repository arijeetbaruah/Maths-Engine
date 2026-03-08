using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Trigonometry
{
    
    [System.Serializable]
    [MathNodeCategory("Trigonometry")]
    public class Sin : BaseMathNode
    {
        [SerializeReference, SerializeField]
        private BaseMathNode _angle;
        
        public override float Calculate(object[] parameter)
        {
            return Mathf.Sin(_angle.Calculate(parameter));
        }
        
        public override string ToEquation() => "Sin(" + _angle.ToEquation() +")";
    }
    
    [System.Serializable]
    [MathNodeCategory("Trigonometry")]
    public class Cos : BaseMathNode
    {
        [SerializeReference, SerializeField]
        private BaseMathNode _angle;
        
        public override float Calculate(object[] parameter)
        {
            return Mathf.Cos(_angle.Calculate(parameter));
        }
        
        public override string ToEquation() => "Cos(" + _angle.ToEquation() +")";
    }
    
    [System.Serializable]
    [MathNodeCategory("Trigonometry")]
    public class Tan : BaseMathNode
    {
        [SerializeReference, SerializeField]
        private BaseMathNode _angle;
        
        public override float Calculate(object[] parameter)
        {
            return Mathf.Tan(_angle.Calculate(parameter));
        }

        public override string ToEquation() => "Tan(" + _angle.ToEquation() +")";
    }
    
    [System.Serializable]
    [MathNodeCategory("Trigonometry")]
    public class Atan2 : BaseMathNode
    {
        [SerializeReference, SerializeField]
        private BaseMathNode _y;
        [SerializeReference, SerializeField]
        private BaseMathNode _x;
        
        public override float Calculate(object[] parameter)
        {
            return Mathf.Atan2(_y.Calculate(parameter), _x.Calculate(parameter));
        }

        public override string ToEquation() => "Atan2(" + _y.ToEquation() + " , " + _x.ToEquation() +")";
    }
    
    
    [System.Serializable]
    [MathNodeCategory("Constants")]
    public class Deg2Rad : BaseMathNode
    {
        public override float Calculate(object[] parameter)
        {
            return Mathf.Deg2Rad;
        }

        public override string ToEquation() => "Deg2Rad";
    }
    
    [System.Serializable]
    [MathNodeCategory("Constants")]
    public class Rad2Deg : BaseMathNode
    {
        public override float Calculate(object[] parameter)
        {
            return Mathf.Rad2Deg;
        }
        
        public override string ToEquation() => "Rad2Deg";
    }
}
