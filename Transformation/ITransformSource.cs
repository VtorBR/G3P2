namespace G3P2.Transformation
{
    public interface ITransformSource
    {
        void Register(out ITransformer subscriber);
    }
}
