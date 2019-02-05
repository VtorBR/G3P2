namespace G3P2.Transform
{
    public interface ITransformSource
    {
        void Subscribe(out ITransformer subscriber);
    }
}
