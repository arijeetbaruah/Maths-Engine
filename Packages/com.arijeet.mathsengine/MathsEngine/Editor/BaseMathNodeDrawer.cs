using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Baruah.MathsEngine.Editor
{
    [CustomPropertyDrawer(typeof(BaseMathNode), true)]
    public class BaseMathNodeDrawer : PropertyDrawer
    {
        private static Dictionary<string, Type> _typeCache;

        private static void BuildTypeCache()
        {
            if (_typeCache != null)
                return;

            _typeCache = TypeCache.GetTypesDerivedFrom<BaseMathNode>()
                .ToDictionary(t => t.Name, t => t);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float height = EditorGUIUtility.singleLineHeight + 8f; // header + padding

            if (property.managedReferenceValue != null)
            {
                SerializedProperty iterator = property.Copy();
                SerializedProperty endProperty = iterator.GetEndProperty();

                iterator.NextVisible(true);

                while (!SerializedProperty.EqualContents(iterator, endProperty))
                {
                    height += EditorGUI.GetPropertyHeight(iterator, true) + 2f;
                    iterator.NextVisible(false);
                }

                height += 4f;
            }
            //height += EditorGUIUtility.singleLineHeight + 2f;

            return height;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            BuildTypeCache();

            EditorGUI.BeginProperty(position, label, property);

            //position.y += EditorGUIUtility.singleLineHeight + 2f;
            // Draw box background
            GUI.Box(position, GUIContent.none, EditorStyles.helpBox);

            float y = position.y + 4f;

            // Header dropdown
            Rect headerRect = new Rect(
                position.x + 6,
                y,
                position.width - 12,
                EditorGUIUtility.singleLineHeight
            );

            headerRect = EditorGUI.PrefixLabel(headerRect, label);

            string currentTypeName = property.managedReferenceValue?.GetType().Name ?? "None";

            if (EditorGUI.DropdownButton(headerRect, new GUIContent(currentTypeName), FocusType.Passive))
            {
                var dropdown = new MathNodeDropdown(new AdvancedDropdownState(), (type) =>
                {
                    property.serializedObject.Update();
                    property.managedReferenceValue = Activator.CreateInstance(type);
                    property.serializedObject.ApplyModifiedProperties();
                });

                dropdown.Show(headerRect);
            }

            y += EditorGUIUtility.singleLineHeight + 6f;

            // Draw children manually
            if (property.managedReferenceValue != null)
            {
                EditorGUI.indentLevel++;

                SerializedProperty iterator = property.Copy();
                SerializedProperty endProperty = iterator.GetEndProperty();

                iterator.NextVisible(true);

                while (!SerializedProperty.EqualContents(iterator, endProperty))
                {
                    float height = EditorGUI.GetPropertyHeight(iterator, true);

                    Rect childRect = new Rect(
                        position.x + 10,
                        y,
                        position.width - 20,
                        height
                    );

                    EditorGUI.PropertyField(childRect, iterator, true);

                    y += height + 2f;

                    iterator.NextVisible(false);
                }

                EditorGUI.indentLevel--;
            }

            EditorGUI.EndProperty();
        }
    }
}
