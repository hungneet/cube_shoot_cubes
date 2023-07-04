using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

[BurstCompile]

public partial struct BulletForward : ISystem
{
    void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<StartGameCommand>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {   var deltaTime = SystemAPI.Time.DeltaTime;
        var ecb = new EntityCommandBuffer(Allocator.TempJob);

        foreach (var (bullet, tf, entity) in SystemAPI.Query<RefRO<Bullet>, RefRW<LocalTransform>>().WithEntityAccess())
        {
            float speed = 10f;
            float direction = tf.ValueRO.Forward().z;
            tf.ValueRW.Position.z += speed*deltaTime*direction;
            if (tf.ValueRO.Position.z > 20)
            {
                ecb.DestroyEntity(entity);
            }
        }
        ecb.Playback(state.EntityManager);
        ecb.Dispose();

    }

  
}

