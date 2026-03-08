namespace Baruah.MathsEngine.Core
{
    /// <summary>
    /// Base class for all math nodes used in the formula engine.
    /// </summary>
    [System.Serializable]
    public abstract class BaseMathNode
    {
        /// /// <summary>
        /// Calculates the value of this node.
        /// </summary>
        /// <param name="parameter">Runtime calculation context.</param>
        /// <returns>Computed value.</returns>
        public abstract float Calculate(object[] parameter);
        /// <summary>
        /// Used by the tool to preview the equation
        /// </summary>
        /// <returns>equation in editor formmate</returns>
        public abstract string ToEquation();
    }
}
