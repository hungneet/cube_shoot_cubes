using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class UserTag : MonoBehaviour
{
    public GameObject _preFab;
    public float _spawnRate;
    public float _timer;
    //public int _count;
}

public struct User:IComponentData
{
    public Entity preFab;
    public float spawnRate;
    public float timer;
    //public int count;
}

public class UserBaker : Baker<UserTag>
{
    public override void Bake(UserTag authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new User { 
            spawnRate = authoring._spawnRate,
            timer = authoring._timer,
            //count = authoring._count,
            preFab = GetEntity(authoring._preFab, TransformUsageFlags.Dynamic)});

    }
}