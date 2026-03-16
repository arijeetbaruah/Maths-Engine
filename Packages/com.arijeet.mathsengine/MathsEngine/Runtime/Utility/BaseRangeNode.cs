using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Utility
{
    public abstract class BaseRangeNode : BaseMathNode
    {
        /// <summary>
        /// First value.
        /// </summary>
        [SerializeField, SerializeReference]
        protected BaseMathNode _a;

        /// <summary>
        /// Second value.
        /// </summary>
        [SerializeField, SerializeReference]
        protected BaseMathNode _b;
    }
}
