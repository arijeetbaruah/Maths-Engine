using UnityEngine;

namespace Baruah.MathsEngine.GameOriented
{
    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class AnimationCurveNode : BaseMathNode
    {
        [SerializeField]
        private AnimationCurve _curve;
        [SerializeReference, SerializeField]
        private BaseMathNode _time;
        
        public override float Calculate(object[] parameter)
        {
            return _curve.Evaluate(_time.Calculate(parameter));
        }
        
        public override string ToEquation() => "AnimationCurve(" + _time.ToEquation() + ")";
    }
    
    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class TimeNode : BaseMathNode
    {
        public override float Calculate(object[] parameter)
        {
            return Time.time;
        }

        public override string ToEquation() => "Time";
    }
    
    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class DeltaTimeNode : BaseMathNode
    {
        public override float Calculate(object[] parameter)
        {
            return Time.deltaTime;
        }
        
        public override string ToEquation() => "DeltaTime";
    }
    
    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class FixedDeltaTimeNode : BaseMathNode
    {
        public override float Calculate(object[] parameter)
        {
            return Time.fixedDeltaTime;
        }
        
        public override string ToEquation() => "FixedDeltaTime";
    }

    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class PingPongNode : BaseMathNode
    {
        [SerializeField, SerializeReference] private BaseMathNode _t;
        [SerializeField, SerializeReference] private BaseMathNode _length;
        
        public override float Calculate(object[] parameter)
        {
            return Mathf.PingPong(_t.Calculate(parameter), _length.Calculate(parameter));
        }
        
        public override string ToEquation() => "PingPong(" + _t.ToEquation() + "," + _length.ToEquation() + ")";
    }
    
    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class SmoothStepNode : BaseMathNode
    {
        [SerializeField, SerializeReference] private BaseMathNode _from;
        [SerializeField, SerializeReference] private BaseMathNode _to;
        [SerializeField, SerializeReference] private BaseMathNode _t;
        
        public override float Calculate(object[] parameter)
        {
            return Mathf.SmoothStep(_from.Calculate(parameter), _to.Calculate(parameter), _t.Calculate(parameter));
        }
        
        public override string ToEquation() => "SmoothStep(" + _from.ToEquation() + "," + _to.ToEquation() +  "," + _t.ToEquation() +")";
    }
    
    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class MoveTowardsNode : BaseMathNode
    {
        [SerializeField, SerializeReference] private BaseMathNode _current;
        [SerializeField, SerializeReference] private BaseMathNode _target;
        [SerializeField, SerializeReference] private BaseMathNode _maxDelta;
        
        public override float Calculate(object[] parameter)
        {
            return Mathf.MoveTowards(_current.Calculate(parameter), _target.Calculate(parameter), _maxDelta.Calculate(parameter));
        }
        
        public override string ToEquation() => "MoveTowards(" + _current.ToEquation() + "," + _target.ToEquation() +  "," + _maxDelta.ToEquation() +")";
    }
    
    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class MinNode : BaseMathNode
    {
        [SerializeField, SerializeReference] private BaseMathNode _a;
        [SerializeField, SerializeReference] private BaseMathNode _b;
        
        public override float Calculate(object[] parameter)
        {
            return Mathf.Min(_a.Calculate(parameter), _b.Calculate(parameter));
        }
        
        public override string ToEquation() => "Min(" + _a.ToEquation() + "," + _b.ToEquation() +")";
    }
    
    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class MaxNode : BaseMathNode
    {
        [SerializeField, SerializeReference] private BaseMathNode _a;
        [SerializeField, SerializeReference] private BaseMathNode _b;
        
        public override float Calculate(object[] parameter)
        {
            return Mathf.Max(_a.Calculate(parameter), _b.Calculate(parameter));
        }
        
        public override string ToEquation() => "Max(" + _a.ToEquation() + "," + _b.ToEquation() +")";
    }
}
