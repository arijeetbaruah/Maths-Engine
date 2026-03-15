using System.Collections.Generic;
using Baruah.MathsEngine.Core;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Baruah.MathsEngine.Editor
{
    [CustomPropertyDrawer(typeof(BaseMathNode), true)]
    public class BaseMathNodeDrawer : PropertyDrawer
    {
        static Dictionary<string, bool> _foldouts = new();

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float height = EditorGUIUtility.singleLineHeight;

            if (!IsExpanded(property)) return height;

            var node = property.objectReferenceValue as BaseMathNode;
            if (node == null) return height;

            var so = new SerializedObject(node);
            var prop = so.GetIterator();
            prop.NextVisible(true);

            while (prop.NextVisible(false))
            {
                if (prop.name == "m_Script") continue;

                height += EditorGUI.GetPropertyHeight(prop, true) + 2;
            }

            return height;
        }

        public override void OnGUI(Rect pos, SerializedProperty property, GUIContent label)
        {
            Rect line = pos;
            line.height = EditorGUIUtility.singleLineHeight;

            EditorGUI.BeginProperty(pos, label, property);

            var node = property.objectReferenceValue as BaseMathNode;

            // Foldout
            SetExpanded(property,
                EditorGUI.Foldout(
                    new Rect(line.x, line.y, 15, line.height),
                    IsExpanded(property),
                    GUIContent.none
                )
            );

            // Field
            Rect fieldRect = line;
            fieldRect.x += 15;
            fieldRect.width -= 80;

            EditorGUI.PropertyField(fieldRect, property, label);

            // NEW button
            Rect newRect = new Rect(pos.xMax - 60, line.y, 30, line.height);
            if (GUI.Button(newRect, "+"))
            {
                ShowDropdown(property, newRect);
            }

            // DELETE button
            Rect delRect = new Rect(pos.xMax - 30, line.y, 30, line.height);
            if (GUI.Button(delRect, "x"))
            {
                DeleteNode(property);
            }

            line.y += line.height + 2;

            // Inline inspector
            if (IsExpanded(property) && node != null)
            {
                DrawNodeInspector(ref line, pos, node);
            }

            EditorGUI.EndProperty();
        }

        void DrawNodeInspector(ref Rect line, Rect pos, BaseMathNode node)
        {
            var so = new SerializedObject(node);
            so.Update();

            var prop = so.GetIterator();
            prop.NextVisible(true);

            while (prop.NextVisible(false))
            {
                if (prop.name == "m_Script") continue;

                float h = EditorGUI.GetPropertyHeight(prop, true);

                Rect r = new Rect(pos.x + 15, line.y, pos.width - 15, h);
                EditorGUI.PropertyField(r, prop, true);

                line.y += h + 2;
            }

            so.ApplyModifiedProperties();
        }

        void ShowDropdown(SerializedProperty property, Rect rect)
        {
            var dropdown = new MathNodeDropdown(
                new AdvancedDropdownState(),
                (type) => CreateNode(property, type)
            );

            dropdown.Show(rect);
        }

        void CreateNode(SerializedProperty property, System.Type type)
        {
            var owner = property.serializedObject.targetObject;

            string path = AssetDatabase.GetAssetPath(owner);

            var formula = AssetDatabase.LoadAssetAtPath<MathFormula>(path);

            if (formula == null)
            {
                Debug.LogError("MathFormula root asset not found.");
                return;
            }

            var node = ScriptableObject.CreateInstance(type) as BaseMathNode;
            node.name = type.Name;

            AssetDatabase.AddObjectToAsset(node, formula);
            AssetDatabase.ImportAsset(path);

            property.objectReferenceValue = node;
            property.serializedObject.ApplyModifiedProperties();

            EditorUtility.SetDirty(formula);
        }

        void DeleteNode(SerializedProperty property)
        {
            var node = property.objectReferenceValue as BaseMathNode;
            if (node == null) return;

            UnityEngine.Object.DestroyImmediate(node, true);
            property.objectReferenceValue = null;

            property.serializedObject.ApplyModifiedProperties();
        }

        bool IsExpanded(SerializedProperty p)
        {
            return _foldouts.TryGetValue(p.propertyPath, out bool v) && v;
        }

        void SetExpanded(SerializedProperty p, bool v)
        {
            _foldouts[p.propertyPath] = v;
        }
    }
}