using System;
using Baruah.MathsEngine.Core;
using UnityEditor;

namespace Baruah.MathsEngine.Editor
{
    [CustomEditor(typeof(MathFormula))]
    public class MathFormulaEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var formula = (MathFormula)target;

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Equation", EditorStyles.boldLabel);

            string formulaStr = "";

            try
            {
                formulaStr = formula.MathNode.ToEquation() + " = " + formula.Calculate();
            }
            catch (Exception e)
            {
                formulaStr = "Something went wrong";
            }
            
            EditorGUILayout.HelpBox(
                formulaStr,
                MessageType.None
            );

            EditorGUILayout.Space();

            DrawDefaultInspector();
        }
    }
}
