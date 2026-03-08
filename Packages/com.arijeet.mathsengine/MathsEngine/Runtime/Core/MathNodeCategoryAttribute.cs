using System;

namespace Baruah.MathsEngine.Attribute
{
    /// <summary>
    /// Attribute used to identify and category Math formula
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MathNodeCategoryAttribute : System.Attribute
    {
        /// <summary>
        /// The Category
        /// </summary>
        public string Category;
        
        public MathNodeCategoryAttribute(string category)
        {
            Category = category;
        }
    }
}
