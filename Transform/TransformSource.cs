using UnityEngine;

namespace G3P2.Transform
{
    public abstract class TransformSource : MonoBehaviour, ITransformSource
    {
        public abstract void Subscribe(out ITransformer subscriber);
    }
}
