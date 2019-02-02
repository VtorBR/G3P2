namespace G3P2
{
    public sealed class Transformer : ITransformer
    {
        private TransformData _transform2D;
        private TransformData _transform3D;

        public TransformData Transform2D
        {
            get { return _transform2D; }
            set
            {
                _transform2D = value;
                _transform3D = TransformDataConverter.Convert2DTo3D(value);
            }
        }

        public TransformData Transform3D
        {
            get { return _transform3D; }
            set
            {
                _transform3D = value;
                _transform2D = TransformDataConverter.Convert3DTo2D(value);
            }
        }
    }
}
