using UnityEngine;

namespace G3P2.Transformation
{
    public abstract class TransformSource : MonoBehaviour, ITransformSource
    {
        protected readonly ITransformer _transformer = new Transformer();

        public void Register(out ITransformer subscriber)
        {
            subscriber = _transformer;
        }
    }
}
