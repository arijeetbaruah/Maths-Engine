using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Utility
{
    /// <summary>
    /// Restricts a value so it stays within a specified range.
    /// </summary>
    /// <remarks>
    /// Internally uses <see cref="Mathf.Clamp"/>.
    /// If the value is less than the minimum it returns the minimum.
    /// If the value is greater than the maximum it returns the maximum.
    /// Otherwise the value is returned unchanged.
    /// </remarks>
    
    [MathNodeCategory("Utility/Range")]
    public class Clamp : BaseMathNode
    {
        /// <summary>
        /// Node that produces the value to be clamped.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _value;

        /// <summary>
        /// Node that defines the minimum allowed value.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _min;

        /// <summary>
        /// Node that defines the maximum allowed value.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _max;

        /// <summary>
        /// Calculates the clamped value.
        /// </summary>
        /// <param name="parameter">Runtime parameters passed through the formula evaluation.</param>
        /// <returns>The clamped result.</returns>
        public override float Calculate(object[] parameter)
        {
            return Mathf.Clamp(
                _value.Calculate(parameter),
                _min.Calculate(parameter),
                _max.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "Clamp(" + _value.ToEquation() + "," + _min.ToEquation() + "," + _max.ToEquation() + ")";
    }


    /// <summary>
    /// Linearly interpolates between two values.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.Lerp"/>.
    /// The interpolation parameter <c>t</c> typically ranges from 0 to 1.
    /// </remarks>
    
    [MathNodeCategory("Utility")]
    public class Lerp : BaseMathNode
    {
        /// <summary>
        /// Starting value.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _a;

        /// <summary>
        /// Ending value.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _b;

        /// <summary>
        /// Interpolation parameter.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _t;

        /// <summary>
        /// Calculates the interpolated value.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Mathf.Lerp(
                _a.Calculate(parameter),
                _b.Calculate(parameter),
                _t.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "Lerp(" + _a.ToEquation() + "," + _b.ToEquation() + "," + _t.ToEquation() + ")";
    }


    /// <summary>
    /// Calculates the interpolation factor between two values.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Mathf.InverseLerp"/>.
    /// Determines where a value lies between two endpoints.
    /// </remarks>
    
    [MathNodeCategory("Utility")]
    public class InverseLerp : BaseMathNode
    {
        /// <summary>
        /// Lower bound of the range.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _a;

        /// <summary>
        /// Upper bound of the range.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _b;

        /// <summary>
        /// Value whose relative position is calculated.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _t;

        /// <summary>
        /// Calculates the normalized interpolation factor.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return Mathf.InverseLerp(
                _a.Calculate(parameter),
                _b.Calculate(parameter),
                _t.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "InverseLerp(" + _a.ToEquation() + "," + _b.ToEquation() + "," + _t.ToEquation() + ")";
    }


    /// <summary>
    /// Generates a random value within a specified range.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="UnityEngine.Random.Range(float,float)"/>.
    /// Each evaluation may return a different result.
    /// </remarks>
    
    [MathNodeCategory("Utility")]
    public class Random : BaseMathNode
    {
        /// <summary>
        /// Node producing the minimum value.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _min;

        /// <summary>
        /// Node producing the maximum value.
        /// </summary>
        [SerializeReference, SerializeField]
        private BaseMathNode _max;

        /// <summary>
        /// Generates a random value between the evaluated min and max.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            return UnityEngine.Random.Range(
                _min.Calculate(parameter),
                _max.Calculate(parameter));
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            "Random(" + _min.ToEquation() + "," + _max.ToEquation() + ")";
    }
}
