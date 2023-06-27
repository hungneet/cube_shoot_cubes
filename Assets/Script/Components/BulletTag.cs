using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

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