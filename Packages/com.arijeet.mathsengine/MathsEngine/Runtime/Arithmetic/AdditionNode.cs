using System.Linq;
using Baruah.MathsEngine.Attribute;

namespace Baruah.MathsEngine.Formula.Arithmetic
{
    /// <summary>
    /// A math node that sums the results of multiple child nodes.
    /// </summary>
    /// <remarks>
    /// Each value node is evaluated and the results are added together.
    /// This node supports any number of inputs.
    /// </remarks>
    
    [MathNodeCategory("Arithmetic")]
    public class AdditionNode : ArithmeticBase
    {
        /// <summary>
        /// Calculates the sum of all child nodes.
        /// </summary>
        /// <param name="parameter">Runtime parameters passed to child nodes.</param>
        /// <returns>The sum of all evaluated nodes.</returns>
        public override float Calculate(object[] parameter)
        {
            float ret = 0;
            foreach (var val in _values)
            {
                ret += val != null ? val.Calculate(parameter) : 0;
            }

            return ret;
        }

        /// <summary>
        /// Returns the equation representation of this node.
        /// </summary>
        public override string ToEquation() =>
            "(" + string.Join(" + ", _values.Select(v => v == null ? "?" : v.ToEquation())) + ")";
    }
}
