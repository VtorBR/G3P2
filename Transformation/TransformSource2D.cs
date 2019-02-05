namespace G3P2.Transformation
{
    public sealed class TransformSource2D : TransformSource
    {
        private void Update()
        {
            _transformer.Transform2D = new TransformData(transform);
        }
    }
}
