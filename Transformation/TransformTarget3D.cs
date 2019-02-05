namespace G3P2.Transformation
{
    public sealed class TransformTarget3D : TransformTarget
    {
        private void LateUpdate()
        {
            TransformData data = _transformer.Transform3D;
            transform.localPosition = data.Position;
            transform.rotation = data.Rotation;
            transform.localScale = data.Scale;
        }
    }
}
