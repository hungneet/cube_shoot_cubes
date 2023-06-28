using Unity.Entities;
using UnityEngine;

public class RotateAuthoring : MonoBehaviour
{
    public float _speed;
}

public struct Rotate : IComponentData
{
    public float speed;
}

public class RotationBaker : Baker<RotateAuthoring>
{
    public override void Bake(RotateAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new Rotate { speed = authoring._speed });

    }
}