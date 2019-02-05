using UnityEngine;

namespace G3P2.Transform
{
    public static class TransformDataConverter
    {
        public static TransformData Convert2DTo3D(TransformData transform2D)
        {
            Quaternion rotation2D = transform2D.Rotation;
            Vector3 position2D = transform2D.Position;
            Vector3 scale2D = transform2D.Scale;

            return new TransformData
            {
                Rotation = new Quaternion(rotation2D.x, -rotation2D.z, rotation2D.y, rotation2D.w),
                Position = new Vector3(position2D.x, position2D.z, position2D.y),
                Scale = new Vector3(scale2D.x, scale2D.z, scale2D.y),
            };
        }

        public static TransformData Convert3DTo2D(TransformData transform3D)
        {
            Quaternion rotation3D = transform3D.Rotation;
            Vector3 position3D = transform3D.Position;
            Vector3 scale3D = transform3D.Scale;

            return new TransformData
            {
                Rotation = new Quaternion(rotation3D.x, rotation3D.z, -rotation3D.y, rotation3D.w),
                Position = new Vector3(position3D.x, position3D.z, position3D.y),
                Scale = new Vector3(scale3D.x, scale3D.z, scale3D.y),
            };
        }
    }
}
