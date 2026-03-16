using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Constants
{
    /// <summary>
    /// A constant value node.
    /// </summary>
    /// <remarks>
    /// This node always returns the same value regardless of input parameters.
    /// Useful for defining numeric constants in formulas.
    /// </remarks>
    [MathNodeCategory("Constants")]
    public class ConstantNode : BaseMathNode
    {
        /// <summary>
        /// The constant value returned by this node.
        /// </summary>
        [SerializeField]
        private float _value;

        /// <summary>
        /// Returns the constant value.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return _value;
        }

        /// <summary>
        /// Returns the equation representation of the constant.
        /// </summary>
        public override string ToEquation() => _value.ToString();
    }
}
