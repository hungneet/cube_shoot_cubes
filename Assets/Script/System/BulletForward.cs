using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

[BurstCompile]
public partial struct BForwardJob : IJobEntity
{
    public float deltaTime;
    public float speed;
    //Ref: RW, in: RO
    void Execute(ref LocalTransform transform, in Bullet bl)
    {

        transform.Position.z += speed * deltaTime;
    }

}

public partial struct BulletForward : ISystem
{


    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {   
        new BForwardJob { deltaTime = SystemAPI.Time.DeltaTime, speed = 10f }.Schedule();
        state.Dependency.Complete();
        DestroyBullet(ref state);

    }

    private void DestroyBullet(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Allocator.TempJob);

        foreach (var (bullet, tf, entity) in SystemAPI.Query<RefRO<Bullet>, RefRO<LocalTransform>>().WithEntityAccess())
        {
            if (tf.ValueRO.Position.z > 20)
            {
                ecb.DestroyEntity(entity);
            }
        }
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}

