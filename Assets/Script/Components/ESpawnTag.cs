using Unity.Entities;
using UnityEngine;

public class ESpawnTag : MonoBehaviour
{
    public GameObject _preFab;
    public int _level = 0;
    public float _spawnRate;
    public int _maxLevel = 2;
}

public struct ESpawn : IComponentData
{
    public Entity preFab;
    public float spawnRate;
    public float level;
    public int maxLevel;
}

public class ESpawnBaker : Baker<ESpawnTag>
{
    public override void Bake(ESpawnTag authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new ESpawn
        {
            spawnRate = authoring._spawnRate,
            level = authoring._level,
            maxLevel = authoring._maxLevel,
            preFab = GetEntity(authoring._preFab, TransformUsageFlags.Dynamic)
        });

    }
}