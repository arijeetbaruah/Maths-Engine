#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;

namespace Baruah.MathsEngine.Core
{
    /// <summary>
    /// ScriptableObject to hold and access Maths Formula
    /// </summary>
    [CreateAssetMenu(fileName = "MathFormula", menuName = "Baruah/MathsEngine/Maths Formula")]
    public class MathFormula : ScriptableObject
    {
        public BaseMathNode MathNode => _node;
     
#if ODIN_INSPECTOR
        [InfoBox("@ToEquation()")]
#endif
        [SerializeField, SerializeReference]
        private BaseMathNode _node;
        
        /// <summary>
        /// Computes the numeric result of the encapsulated math node using the provided inputs.
        /// </summary>
        /// <param name="parameter">A variable list of inputs passed to the underlying math node; expected types and order depend on the node implementation.</param>
        /// <returns>The computed result as a float.</returns>
        public float Calculate(params object[] parameter)
        {
            return _node.Calculate(parameter);
        }

        /// <summary>
        /// Produce a single string that presents the node's equation followed by its evaluated numeric result.
        /// </summary>
        /// <returns>A string in the format "&lt;equation&gt; = &lt;value&gt;", where &lt;equation&gt; is the node's equation and &lt;value&gt; is the result of evaluating the formula.</returns>
        public string ToEquation() => MathNode.ToEquation() + " = " + Calculate();
    }
}
