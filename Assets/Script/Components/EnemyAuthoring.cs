using Unity.Entities;
using UnityEngine;

public class EnemyAuthoring : MonoBehaviour
{
    public float _speed;
}

public struct EnemyComponent : IComponentData
{
    public float speed;
}

public class RotationBaker : Baker<EnemyAuthoring>
{
    public override void Bake(EnemyAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new EnemyComponent { speed = authoring._speed });

    }
}