using UnityEngine;

namespace G3P2
{
    public abstract class TransformSource : MonoBehaviour, ITransformSource
    {
        public abstract void Subscribe(out ITransformer subscriber);
    }
}
