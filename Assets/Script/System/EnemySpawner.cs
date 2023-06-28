using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;


public partial struct EnemySpawner : ISystem
{
    // Start is called before the first frame update
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {

        //var espawn = SystemAPI.GetSingletonEntity<ESpawn>();
        Unity.Mathematics.Random random = new Unity.Mathematics.Random(1);
        state.Enabled = false;
        var spawner = SystemAPI.GetSingletonRW<ESpawn>();
        var enemy = spawner.ValueRW.preFab;
        var ecb = new EntityCommandBuffer(Allocator.TempJob);
        //state.EntityManager.SetComponentData()
        for (int i = 0; i < 1; i++)
        {
            var newEnemy = ecb.Instantiate(enemy);
            ecb.SetComponent(newEnemy, new LocalTransform
            {
                Position = new float3(random.NextFloat(-15f, 20f), 0, random.NextFloat(-2f, 10f)),
                Rotation = quaternion.identity,
                Scale = 1f
            });
        }
        ecb.Playback(state.EntityManager);
        /*
        float deltaTime = SystemAPI.Time.DeltaTime;
        foreach (var (transform, spawner) in SystemAPI.Query<RefRW<LocalTransform>, RefRW<ESpawn>>())
        {
            transform.ValueRW.Position = RandomPos();
            
            if (spawner.ValueRW.timer < spawner.ValueRW.spawnRate)
            {
                spawner.ValueRW.timer += deltaTime;
            }
            else
            {   
                Entity bulletspawn = spawner.ValueRW.preFab;
                state.EntityManager.SetComponentData(bulletspawn, new LocalTransform
                {
                    Position = transform.ValueRW.Position,
                    Rotation = quaternion.identity,
                    Scale =3f
                });
                state.EntityManager.Instantiate(bulletspawn);
                spawner.ValueRW.timer = 0;

            }
        }*/
    }


}
