namespace G3P2.Transformation
{
    public interface ITransformSource
    {
        void Subscribe(out ITransformer subscriber);
    }
}
