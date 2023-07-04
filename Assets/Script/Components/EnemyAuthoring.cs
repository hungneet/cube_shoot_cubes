using Unity.Entities;
using UnityEngine;

public class EnemyAuthoring : MonoBehaviour
{   
    public float _speed;
    public float _spawnRate;
    public float _timer = 0f;
    //public GameObject _preFab;
}

public struct EnemyComponent : IComponentData
{   
    public float speed;
    public float spawnRate;
    public float timer;
    //public Entity preFab;
}



public class RotationBaker : Baker<EnemyAuthoring>
{
    public override void Bake(EnemyAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new EnemyComponent { speed = authoring._speed ,
            //preFab = GetEntity(authoring._preFab, TransformUsageFlags.Dynamic),
            spawnRate = authoring._spawnRate,
            timer = authoring._timer
        });
    }
}