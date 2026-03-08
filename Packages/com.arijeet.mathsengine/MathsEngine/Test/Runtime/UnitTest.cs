using System.Linq;
using Baruah.MathsEngine.Core;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace Baruah.MathsEngine.Test
{
    public class UnitTest
    {
        [TestCase("Test_MathFormula_01", 5)]
        [TestCase("Test_MathFormula_02", 1)]
        public void ScriptableFormula_Evaluates_Correctly(string fileName, int targetResult)
        {
            // -------- Load real designer asset --------
            var assets = AssetDatabase.FindAssets($"t:{nameof(MathFormula)} {fileName}");
            var formulaAsset = assets
                .Select(assets => AssetDatabase.LoadAssetAtPath<MathFormula>(AssetDatabase.GUIDToAssetPath(assets)))
                .FirstOrDefault();

            Assert.IsNotNull(formulaAsset, 
                "Formula asset not found. Check asset path.");

            float result = formulaAsset.Calculate();
            Assert.AreEqual(targetResult, result, 0.0001f, "ScriptableObject formula evaluation failed.");
        }
    }
}
