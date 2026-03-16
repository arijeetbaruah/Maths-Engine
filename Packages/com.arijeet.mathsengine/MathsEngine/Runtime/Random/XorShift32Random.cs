using System;
using Baruah.MathsEngine.Attribute;
using Baruah.MathsEngine.Core;
using UnityEngine;

namespace Baruah.MathsEngine.Formula.Random
{
    [MathNodeCategory("Random")]
    public class XorShift32Random : BaseMathNode
    {
        /// <summary>
        /// Seed for number generator
        /// </summary>
        [SerializeField]
        private uint _seed;

        private uint _state;
        
        public uint NextUInt()
        {
            uint x = _state;
            x ^= x << 13;
            x ^= x >> 17;
            x ^= x << 5;
            _state = x;
            return x;
        }
        public float NextFloat()
        {
            return NextUInt() / (float)uint.MaxValue;
        }
        
        /// <summary>
        /// Generates a random value between the evaluated min and max.
        /// </summary>
        public override float Calculate(object[] parameter)
        {
            _state = (_seed != 0 ? _seed : 1) * (uint) DateTime.Now.Millisecond;
            
            return NextFloat();
        }

        /// <summary>
        /// Returns the equation representation.
        /// </summary>
        public override string ToEquation() =>
            $"XorShiftRand({_seed})";
    }
}
