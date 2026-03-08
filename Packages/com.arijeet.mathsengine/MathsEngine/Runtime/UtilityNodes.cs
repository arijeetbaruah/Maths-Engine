using UnityEngine;

namespace Baruah.MathsEngine.Utility
{
    [System.Serializable]
    [MathNodeCategory("Utility/Range")]
    public class Clamp : BaseMathNode
    {
        [SerializeReference, SerializeField]
        private BaseMathNode _value;
        [SerializeReference, SerializeField]
        private BaseMathNode _min;
        [SerializeReference, SerializeField]
        private BaseMathNode _max;
        
        public override float Calculate(object[] parameter)
        {
            return Mathf.Clamp(_value.Calculate(parameter), _min.Calculate(parameter), _max.Calculate(parameter));
        }
        
        public override string ToEquation() => "Clamp(" + _value.ToEquation() + "," + _min.ToEquation() + "," + _max.ToEquation() + ")";
    }
    
    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class Lerp : BaseMathNode
    {
        [SerializeReference, SerializeField]
        private BaseMathNode _a;
        [SerializeReference, SerializeField]
        private BaseMathNode _b;
        [SerializeReference, SerializeField]
        private BaseMathNode _t;
        
        public override float Calculate(object[] parameter)
        {
            return Mathf.Lerp(_a.Calculate(parameter), _b.Calculate(parameter), _t.Calculate(parameter));
        }
        
        public override string ToEquation() => "Lerp(" + _a.ToEquation() + "," + _b.ToEquation() + "," + _t.ToEquation() + ")";
    }
    
    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class InverseLerp : BaseMathNode
    {
        [SerializeReference, SerializeField]
        private BaseMathNode _a;
        [SerializeReference, SerializeField]
        private BaseMathNode _b;
        [SerializeReference, SerializeField]
        private BaseMathNode _t;
        
        public override float Calculate(object[] parameter)
        {
            return Mathf.InverseLerp(_a.Calculate(parameter), _b.Calculate(parameter), _t.Calculate(parameter));
        }
        
        public override string ToEquation() => "InverseLerp(" + _a.ToEquation() + "," + _b.ToEquation() + "," + _t.ToEquation() + ")";

    }
    
    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class Random : BaseMathNode
    {
        [SerializeReference, SerializeField]
        private BaseMathNode _min;
        [SerializeReference, SerializeField]
        private BaseMathNode _max;
        
        public override float Calculate(object[] parameter)
        {
            return UnityEngine.Random.Range(_min.Calculate(parameter), _max.Calculate(parameter));
        }
        
        public override string ToEquation() => "Random(" + _min.ToEquation() + "," + _max.ToEquation() + ")";

    }
}
