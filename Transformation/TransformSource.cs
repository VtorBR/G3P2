using UnityEngine;

namespace G3P2.Transformation
{
    public abstract class TransformSource : MonoBehaviour, ITransformSource
    {
        public abstract void Subscribe(out ITransformer subscriber);
    }
}
