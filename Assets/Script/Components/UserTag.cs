using Unity.Entities;
using UnityEngine;

public class UserTag : MonoBehaviour
{
    public GameObject _preFab;
    public float _spawnRate;
    public float _timer;
}

public struct User : IComponentData
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
        AddComponent(entity, new User
        {
            spawnRate = authoring._spawnRate,
            timer = authoring._timer,
            preFab = GetEntity(authoring._preFab, TransformUsageFlags.Dynamic)
        });

    }
}