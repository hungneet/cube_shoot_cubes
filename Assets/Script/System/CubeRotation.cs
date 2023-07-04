using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial struct CubeMoveJob : IJobEntity
{
    public float deltaTime;
    void Execute(ref LocalTransform transform, ref EnemyComponent enemy)
    {
        if (Mathf.Abs(transform.Position.x) >= 24.5f)
        {
            enemy.speed = -enemy.speed;
        }
        transform.Position = new Unity.Mathematics.float3
        {
            x = transform.Position.x + enemy.speed * deltaTime,
            y = transform.Position.y,
            z = transform.Position.z
        };
    }
}
public partial struct CubeRotation : ISystem
{
    void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<StartGameCommand>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        /*float deltaTime = SystemAPI.Time.DeltaTime;
        foreach (var (transform,rotate) in SystemAPI.Query<RefRW<LocalTransform>,RefRW<Rotate>>()) {
            
            if(Mathf.Abs(transform.ValueRW.Position.x )> 25 )
            {
                rotate.ValueRW.speed = -rotate.ValueRW.speed;
            }
            transform.ValueRW.Position = new Unity.Mathematics.float3
            {
                x = transform.ValueRW.Position.x + rotate.ValueRO.speed * deltaTime,
                y = transform.ValueRW.Position.y,
                z = transform.ValueRW.Position.z
            };
       


        }*/
        var moveJob = new CubeMoveJob { deltaTime = SystemAPI.Time.DeltaTime };
        moveJob.Schedule();
        
    }
}
