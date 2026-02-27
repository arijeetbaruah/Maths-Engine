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
    }
    
    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class TimeNode : BaseMathNode
    {
        public override float Calculate(object[] parameter)
        {
            return Time.time;
        }
    }
    
    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class DeltaTimeNode : BaseMathNode
    {
        public override float Calculate(object[] parameter)
        {
            return Time.deltaTime;
        }
    }
    [System.Serializable]
    [MathNodeCategory("Utility")]
    public class FixedDeltaTimeNode : BaseMathNode
    {
        public override float Calculate(object[] parameter)
        {
            return Time.fixedDeltaTime;
        }
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
    }
}
