using Unity.Entities;
using UnityEngine;

public class BulletTag : MonoBehaviour
{
}

public struct Bullet : IComponentData
{

}

public class BulletBaker : Baker<BulletTag>
{
    public override void Bake(BulletTag authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new Bullet { });

    }
}