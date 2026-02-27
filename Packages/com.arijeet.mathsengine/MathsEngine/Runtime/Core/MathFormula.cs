using UnityEngine;

namespace Baruah.MathsEngine
{
    [System.Serializable]
    public class MathFormula
    {
        [SerializeField, SerializeReference]
        private BaseMathNode _node;
        
        public float Calculate(params object[] parameter)
        {
            return _node.Calculate(parameter);
        }
    }
}
