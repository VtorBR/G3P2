using UnityEngine;

namespace G3P2.Transformation
{
    public sealed class TransformTarget3D : MonoBehaviour
    {
        [SerializeField]
        private TransformSource _transformSource;
        private ITransformer _transformer;

        private void Start()
        {
            _transformSource.Subscribe(out _transformer);
        }

        private void LateUpdate()
        {
            TransformData data = _transformer.Transform3D;
            transform.localPosition = data.Position;
            transform.rotation = data.Rotation;
            transform.localScale = data.Scale;
        }
    }
}
