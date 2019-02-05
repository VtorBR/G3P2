namespace G3P2.Transform
{
    public interface ITransformer
    {
        TransformData Transform2D { get; set; }
        TransformData Transform3D { get; set; }
    }
}
