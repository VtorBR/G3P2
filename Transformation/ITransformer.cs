namespace G3P2.Transformation
{
    public interface ITransformer
    {
        TransformData Transform2D { get; set; }
        TransformData Transform3D { get; set; }
    }
}
