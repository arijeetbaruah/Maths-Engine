#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using System.Collections.Generic;
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
        
        [SerializeField, HideInInspector] private List<BaseMathNode> _nodes = new();
        
        /// <summary>
        /// List of all nodes in the formula
        /// </summary>
        public IReadOnlyList<BaseMathNode> Nodes => _nodes;
        
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
        public string ToEquation()
        {
            string result = "";
            try
            {
                if (_node == null)
                {
                    return "0";
                }
                
                result = _node.ToEquation();

                result += " = " + _node.Calculate(new object[0]);
            }
            catch (System.Exception ex)
            {
                Debug.LogException(ex);
                result = "0";
            }
            
            return result;
        }

        /// <summary>
        /// Removes a node from the formula. (UNITY_EDITOR only)
        /// </summary>
        /// <param name="node">Node to be removed</param>
        public void RemoveNode(BaseMathNode node)
        {
            #if UNITY_EDITOR
            _nodes.Remove(node);
            
            DestroyImmediate(node, true);

            UnityEditor.EditorUtility.SetDirty(this);
            UnityEditor.AssetDatabase.SaveAssets();

            #else
            throw new System.PlatformNotSupportedException("This function is not supported on this platform.");
            #endif
        }

        public void AddNode<T>(T node) where T : BaseMathNode
        {
#if UNITY_EDITOR
            _nodes.Add(node);

            UnityEditor.EditorUtility.SetDirty(this);
            UnityEditor.AssetDatabase.SaveAssets();

#else
            throw new System.PlatformNotSupportedException("This function is not supported on this platform.");
#endif
        }
    }
}
