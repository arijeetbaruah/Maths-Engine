using UnityEngine;

namespace Baruah.MathsEngine.Arithmetic
{
    [System.Serializable]
    [MathNodeCategory("Arithmetic")]
    public class AdditionNode : BaseMathNode
    {
        [SerializeReference, SerializeField]
        private BaseMathNode[] _values;
        
        public override float Calculate(object[] parameter)
        {
            float ret = 0;
            foreach (var val in _values)
            {
                ret += val.Calculate(parameter);
            }
            
            return ret;
        }
    }
    
    [System.Serializable]
    [MathNodeCategory("Arithmetic")]
    public class SubtractionNode : BaseMathNode
    {
        [SerializeReference, SerializeField]
        private BaseMathNode[] _values;
        
        public override float Calculate(object[] parameter)
        {
            float ret = _values[0].Calculate(parameter);
            for(int index = 1; index < _values.Length; index++)
            {
                ret -= _values[index].Calculate(parameter);
            }
            
            return ret;
        }
    }
    
    [System.Serializable]
    [MathNodeCategory("Arithmetic")]
    public class MultiplicationNode : BaseMathNode
    {
        [SerializeReference, SerializeField]
        private BaseMathNode[] _values;
        
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
    }
    
    [System.Serializable]
    [MathNodeCategory("Arithmetic")]
    public class DivisionNode : BaseMathNode
    {
        [SerializeReference, SerializeField]
        private BaseMathNode _numerator;
        [SerializeReference, SerializeField]
        private BaseMathNode _denominator;
        
        public override float Calculate(object[] parameter)
        {
            return _numerator.Calculate(parameter) / _denominator.Calculate(parameter);
        }
    }
    
    [System.Serializable]
    [MathNodeCategory("Constants")]
    public class ConstantNode : BaseMathNode
    {
        [SerializeField]
        private float _value;
        
        public override float Calculate(object[] parameter)
        {
            return _value;
        }
    }
    
    [System.Serializable]
    [MathNodeCategory("Arithmetic")]
    public class Modulo : BaseMathNode
    {
        [SerializeReference, SerializeField]
        private BaseMathNode _num1;
        [SerializeReference, SerializeField]
        private BaseMathNode _num2;
        
        public override float Calculate(object[] parameter)
        {
            return _num1.Calculate(parameter) % _num2.Calculate(parameter);
        }
    }
    
    [System.Serializable]
    [MathNodeCategory("Arithmetic")]
    public class Power : BaseMathNode
    {
        [SerializeReference, SerializeField]
        private BaseMathNode _num1;
        [SerializeReference, SerializeField]
        private BaseMathNode _num2;
        
        public override float Calculate(object[] parameter)
        {
            return Mathf.Pow(_num1.Calculate(parameter), _num2.Calculate(parameter));
        }
    }
    
    [System.Serializable]
    [MathNodeCategory("Arithmetic")]
    public class Absolute : BaseMathNode
    {
        [SerializeReference, SerializeField]
        private BaseMathNode _num;
        
        public override float Calculate(object[] parameter)
        {
            return Mathf.Abs(_num.Calculate(parameter));
        }
    }
    
    [System.Serializable]
    [MathNodeCategory("Arithmetic")]
    public class Negate : BaseMathNode
    {
        [SerializeReference, SerializeField]
        private BaseMathNode _num;
        
        public override float Calculate(object[] parameter)
        {
            return -_num.Calculate(parameter);
        }
    }
}
