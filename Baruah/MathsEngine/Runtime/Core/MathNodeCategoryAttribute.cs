using System;

namespace Baruah.MathsEngine
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MathNodeCategoryAttribute : Attribute
    {
        public string Path;
        public MathNodeCategoryAttribute(string path)
        {
            Path = path;
        }
    }
}
