using Unity.Entities;
using UnityEngine;

public class ESpawnTag : MonoBehaviour
{
    public GameObject _preFab;
    public float _timer = 0;
    public float _spawnRate;
}

public struct ESpawn : IComponentData
{
    public Entity preFab;
    public float spawnRate;
    public float timer;
}

public class ESpawnBaker : Baker<ESpawnTag>
{
    public override void Bake(ESpawnTag authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new ESpawn
        {
            spawnRate = authoring._spawnRate,
            timer = authoring._timer,
            preFab = GetEntity(authoring._preFab, TransformUsageFlags.Dynamic)
        });

    }
}