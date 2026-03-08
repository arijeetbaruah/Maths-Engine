#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;

namespace Baruah.MathsEngine
{
    [CreateAssetMenu(fileName = "MathFormula", menuName = "Baruah/MathsEngine/Maths Formula")]
    public class MathFormula : ScriptableObject
    {
        public BaseMathNode MathNode => _node;
     
        [InfoBox("@ToEquation()")]

        [SerializeField, SerializeReference]
        private BaseMathNode _node;
        
        public float Calculate(params object[] parameter)
        {
            return _node.Calculate(parameter);
        }

        public string ToEquation() => MathNode.ToEquation() + " = " + Calculate();
    }
}
