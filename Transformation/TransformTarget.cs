using UnityEngine;

namespace G3P2.Transformation
{
    public abstract class TransformTarget : MonoBehaviour, ITransformTarget
    {
        protected ITransformer _transformer;

        public void SubscribeTo(ITransformSource source)
        {
            source.Register(out _transformer);
        }
    }
}
