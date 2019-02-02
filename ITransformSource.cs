namespace G3P2
{
    public interface ITransformSource
    {
        void Subscribe(out ITransformer subscriber);
    }
}
