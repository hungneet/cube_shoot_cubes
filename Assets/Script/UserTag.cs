using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class UserTag : MonoBehaviour
{
}

public struct User:IComponentData
{

}

public class UserBaker : Baker<UserTag>
{
    public override void Bake(UserTag authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new User { });

    }
}