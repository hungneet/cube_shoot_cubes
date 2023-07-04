using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct EnemySpawner : ISystem
{
    void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<StartGameCommand>();
    }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var spawner = SystemAPI.GetSingletonRW<ESpawn>();
        if (spawner.ValueRO.level !=1) return;
        state.Enabled = false;
        var enemy = spawner.ValueRO.preFab;
        var ecb = new EntityCommandBuffer(Allocator.TempJob);
        Unity.Mathematics.Random random = new Unity.Mathematics.Random(1);
        for (int i = 0; i < spawner.ValueRO.spawnRate; i++)
        {
            var newEnemy = ecb.Instantiate(enemy);
            ecb.SetComponent(newEnemy, new LocalTransform
            {
                Position = new float3(random.NextFloat(-20f,20f),0f,random.NextFloat(-2f,10f)),
                Rotation = quaternion.identity,
                Scale = 1f
            });
        }
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}
