using UnityEngine;

namespace Baruah.MathsEngine
{
    [CreateAssetMenu(fileName = "MathFormula", menuName = "Baruah/MathsEngine/Maths Formula")]
    public class MathFormula : ScriptableObject
    {
        [SerializeField, SerializeReference]
        private BaseMathNode _node;
        
        public float Calculate(params object[] parameter)
        {
            return _node.Calculate(parameter);
        }
    }
}
