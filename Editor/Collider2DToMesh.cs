using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace G3P2
{
    public static class Collider2DToMesh
    {
        private static readonly Dictionary<Type, Action<Collider2D>> Volumizers = new Dictionary<Type, Action<Collider2D>>
        {
            { typeof(BoxCollider2D), BoxVolumizer },
            { typeof(CapsuleCollider2D), CapsuleVolumizer },
            { typeof(CircleCollider2D), CircleVolumizer },
        };

        [MenuItem("G3P2/Volumize 2D Colliders")]
        private static void Volumize()
        {
            Action<Collider2D> volumizer;
            foreach (Collider2D collider in UnityEngine.Object.FindObjectsOfType<Collider2D>())
            {
                if (Volumizers.TryGetValue(collider.GetType(), out volumizer))
                {
                    volumizer(collider);
                }
                else
                {
                    Debug.LogWarningFormat(collider, "Collider2D type not supported: {0}", collider.GetType());
                }
            }
        }

        private static void CreatePrimitive(string name, PrimitiveType primitive, TransformData transformData)
        {
            Transform transform = GameObject.CreatePrimitive(primitive).transform;
            transform.name = name;
            transform.localPosition = transformData.Position;
            transform.localRotation = transformData.Rotation;
            transform.localScale = transformData.Scale;
        }

        private static void BoxVolumizer(Collider2D collider)
        {
            TransformData transformData = Box2DToTransformData(collider as BoxCollider2D);
            transformData = TransformDataConverter.Convert2DTo3D(transformData);
            CreatePrimitive(collider.name + " Volumized", PrimitiveType.Cube, transformData);
        }

        private static void CapsuleVolumizer(Collider2D collider)
        {
            TransformData transformData = Capsule2DToTransformData(collider as CapsuleCollider2D);
            transformData = TransformDataConverter.Convert2DTo3D(transformData);
            CreatePrimitive(collider.name + " Volumized", PrimitiveType.Capsule, transformData);
        }

        private static void CircleVolumizer(Collider2D collider)
        {
            TransformData transformData = Circle2DToTransformData(collider as CircleCollider2D);
            transformData = TransformDataConverter.Convert2DTo3D(transformData);
            CreatePrimitive(collider.name + " Volumized", PrimitiveType.Sphere, transformData);
        }

        private static TransformData Box2DToTransformData(BoxCollider2D boxCollider)
        {
            Vector3 offset = new Vector3(boxCollider.offset.x, boxCollider.offset.y, 0f);
            Vector3 size = new Vector3(boxCollider.size.x, boxCollider.size.y, 1f);

            return new TransformData
            {
                Rotation = boxCollider.transform.rotation,
                Position = boxCollider.transform.TransformPoint(offset),
                Scale = Vector3.Scale(boxCollider.transform.lossyScale, size),
            };
        }

        private static TransformData Capsule2DToTransformData(CapsuleCollider2D capsuleCollider)
        {
            Vector3 offset = new Vector3(capsuleCollider.offset.x, capsuleCollider.offset.y, 0f);
            Quaternion rotation = capsuleCollider.transform.rotation;
            Vector3 scale = capsuleCollider.transform.lossyScale;
            Vector3 size = capsuleCollider.size;
            switch (capsuleCollider.direction)
            {
                case CapsuleDirection2D.Vertical:
                    scale.z = scale.x;
                    scale.y *= .5f;
                    size.z = size.x;
                    rotation *= Quaternion.AngleAxis(90f, Vector3.right);
                    break;
                case CapsuleDirection2D.Horizontal:
                    scale.z = scale.y;
                    scale.x *= .5f;
                    size.z = size.y;
                    rotation *= Quaternion.AngleAxis(90f, Vector3.up);
                    rotation *= Quaternion.AngleAxis(90f, Vector3.forward);
                    break;
                default:
                    break;
            }

            return new TransformData
            {
                Rotation = rotation,
                Position = capsuleCollider.transform.TransformPoint(offset),
                Scale = Vector3.Scale(scale, size),
            };
        }

        private static TransformData Circle2DToTransformData(CircleCollider2D circleCollider)
        {
            Vector3 offset = new Vector3(circleCollider.offset.x, circleCollider.offset.y, 0f);
            float radius = circleCollider.radius;
            radius *= Mathf.Max(circleCollider.transform.lossyScale.x, circleCollider.transform.lossyScale.y);

            return new TransformData
            {
                Rotation = circleCollider.transform.rotation,
                Position = circleCollider.transform.TransformPoint(offset),
                Scale = Vector3.one * radius * 2f,
            };
        }
    }
}
