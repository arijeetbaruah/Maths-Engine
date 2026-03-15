using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine
{
    public class MathEngineExample : MonoBehaviour
    {
        [SerializeField]
        private MathFormula _formula;

        private void Start()
        {
            float value = _formula.Calculate();
            
            Debug.Log(value);
        }
    }
}
