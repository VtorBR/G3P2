using G3P2.Transformation;
using UnityEngine;

namespace G3P2.Instantiation
{
    [CreateAssetMenu(fileName = "new Dual Prefab", menuName = "G3P2/Dual Prefab")]
    public sealed class DualPrefabScriptableObject : ScriptableObject
    {
        [SerializeField]
        private TransformSource _source;
        [SerializeField]
        private TransformTarget _target;

        public void Instantiate(Transform sourceParent, Transform targetParent)
        {
            Instantiate(_target, targetParent).SubscribeTo(Instantiate(_source, sourceParent));
        }
    }
}
