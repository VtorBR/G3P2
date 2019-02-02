using System;
using UnityEngine;

namespace G3P2
{
    [Serializable]
    public struct TransformData
    {
        public Quaternion Rotation;
        public Vector3 Position;
        public Vector3 Scale;

        public TransformData(Transform transform)
        {
            Rotation = transform.localRotation;
            Position = transform.localPosition;
            Scale = transform.localScale;
        }
    } 
}
