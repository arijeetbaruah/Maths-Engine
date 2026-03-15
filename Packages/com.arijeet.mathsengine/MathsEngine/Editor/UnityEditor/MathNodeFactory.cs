using Baruah.MathsEngine.Core;
using UnityEditor;
using UnityEngine;

namespace Baruah.MathsEngine.Editor
{
    public static class MathNodeFactory
    {
        public static T CreateNode<T>(MathFormula formula) where T : BaseMathNode
        {
            T node = ScriptableObject.CreateInstance<T>();
            node.name = typeof(T).Name;

            AssetDatabase.AddObjectToAsset(node, formula);
            AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(formula));

            formula.AddNode(node);

            EditorUtility.SetDirty(formula);

            return node;
        }
    }
}
