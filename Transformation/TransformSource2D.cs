namespace G3P2.Transformation
{
    public sealed class TransformSource2D : TransformSource
    {
        private readonly ITransformer _transformer = new Transformer();

        private void Update()
        {
            _transformer.Transform2D = new TransformData(transform);
        }

        public override void Subscribe(out ITransformer subscriber)
        {
            subscriber = _transformer;
        }
    }
}
