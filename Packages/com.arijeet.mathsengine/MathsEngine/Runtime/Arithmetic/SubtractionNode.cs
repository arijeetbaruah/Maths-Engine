using System.Linq;
using Baruah.MathsEngine.Attribute;

namespace Baruah.MathsEngine.Formula.Arithmetic
{
    /// <summary>
    /// A math node that subtracts multiple values sequentially.
    /// </summary>
    /// <remarks>
    /// The first node acts as the starting value and all subsequent
    /// nodes are subtracted from it.
    /// </remarks>
    [MathNodeCategory("Arithmetic")]
    public class SubtractionNode : ArithmeticBase
    {
        /// <summary>
        /// Calculates the subtraction chain.
        /// </summary>
        /// <param name="parameter">Runtime parameters passed to child nodes.</param>
        /// <summary>
        /// Computes the subtraction chain where the first child provides the initial value and each subsequent child is subtracted in order. If a child node is null, it is treated as zero.
        /// </summary>
        /// <param name="parameter">Arguments forwarded to each child node's Calculate method.</param>
        /// <returns>The accumulated subtraction result as a float.</returns>
        public override float Calculate(object[] parameter)
        {
            float ret = _values[0].Calculate(parameter);

            for (int index = 1; index < _values.Count; index++)
            {
                ret -= _values[index] != null ? _values[index].Calculate(parameter) : 0;
            }

            return ret;
        }

        /// <summary>
        /// Returns the equation representation of the subtraction.
        /// </summary>
        public override string ToEquation() =>
            "(" + string.Join(" - ", _values.Select(v => v == null ? "?" : v.ToEquation())) + ")";
    }
}
