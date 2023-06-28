
using Components;
using Unity.Collections;
using Unity.Entities;

public partial struct hpSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Allocator.Temp);

        foreach (var (hp, entity) in SystemAPI.Query<RefRO<HPComponent>>().WithEntityAccess())
        {
            if (hp.ValueRO.health <= 0)
            {
                ecb.AddComponent(entity, new Destroy { });
            }
        }

        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }

}