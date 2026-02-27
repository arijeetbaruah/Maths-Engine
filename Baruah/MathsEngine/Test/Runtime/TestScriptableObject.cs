using UnityEngine;

namespace Baruah.MathsEngine.Test
{
    [CreateAssetMenu(fileName = "TestScriptableObject", menuName = "Scriptable Objects/TestScriptableObject")]
    public class TestScriptableObject : ScriptableObject
    {
        [SerializeField] private MathFormula _formula;
    }
}
