namespace Baruah.MathsEngine
{
    [System.Serializable]
    public abstract class BaseMathNode
    {
        public abstract float Calculate(object[] parameter);
        public abstract string ToEquation();
    }
}
