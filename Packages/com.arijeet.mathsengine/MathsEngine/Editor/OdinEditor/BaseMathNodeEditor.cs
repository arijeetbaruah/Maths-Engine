using System;
using System.Linq;
using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Baruah.MathsEngine.Editor
{
    public class BaseMathNodeEditor : OdinValueDrawer<BaseMathNode>
    {
        private bool _expanded;
        private PropertyTree _tree;

        protected override void DrawPropertyLayout(GUIContent label)
        {
            var node = ValueEntry.SmartValue;

            SirenixEditorGUI.BeginBox();

            // Header
            SirenixEditorGUI.BeginBoxHeader();

            _expanded = SirenixEditorGUI.Foldout(_expanded, label ?? GUIContent.none);

            GUILayout.FlexibleSpace();

            if (GUILayout.Button("+", GUILayout.Width(25)))
            {
                ShowSelector();
            }

            if (GUILayout.Button("x", GUILayout.Width(25)))
            {
                DeleteNode();
            }

            SirenixEditorGUI.EndBoxHeader();

            // Inline inspector
            if (_expanded && node != null)
            {
                DrawNode(node);
            }

            SirenixEditorGUI.EndBox();
        }
        
        void DrawNode(BaseMathNode node)
        {
            if (_tree == null || _tree.WeakTargets[0] != node)
            {
                _tree?.Dispose();
                _tree = PropertyTree.Create(node);
            }

            _tree.Draw(false);
        }
        
        private void ShowSelector()
        {
            var types = TypeCache
                .GetTypesDerivedFrom<BaseMathNode>()
                .Where(t => !t.IsAbstract);

            var selector = new GenericSelector<Type>(
                "Select Math Node",
                false,
                t => GetCateoryNames(t),
                types
            );

            selector.SelectionConfirmed += selection =>
            {
                CreateNode(selection.FirstOrDefault());
            };

            selector.ShowInPopup();
        }

        private string GetCateoryNames(Type type)
        {
            string path = type.Name;
            var category = type.GetCustomAttributes(typeof(MathNodeCategoryAttribute), false)
                .FirstOrDefault() as MathNodeCategoryAttribute;

            if (category != null)
                path = category.Category + "/" + type.Name;

            return path;
        }

        private void CreateNode(Type type)
        {
            if (type == null) return;

            var owner = Property.Tree.WeakTargets[0];
            string path = AssetDatabase.GetAssetPath((Object) owner);

            var node = ScriptableObject.CreateInstance(type) as BaseMathNode;
            node.name = type.Name;

            AssetDatabase.AddObjectToAsset(node, path);
            AssetDatabase.ImportAsset(path);
            if (owner is MathFormula mathFormula)
            {
                mathFormula.AddNode(node);
            }

            ValueEntry.SmartValue = node;

            GUI.changed = true;
        }

        private void DeleteNode()
        {
            var owner = Property.Tree.WeakTargets[0];
            
            var node = ValueEntry.SmartValue;

            if (node == null) return;
            
            if (owner is MathFormula mathFormula)
            {
                mathFormula.AddNode(node);
            }
            
            UnityEngine.Object.DestroyImmediate(node, true);
            ValueEntry.SmartValue = null;
        }
    }
}
