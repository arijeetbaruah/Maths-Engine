using System;

namespace Baruah.MathsEngine.Attribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MathNodeCategoryAttribute : System.Attribute
    {
        public string Path;
        public MathNodeCategoryAttribute(string path)
        {
            Path = path;
        }
    }
}
