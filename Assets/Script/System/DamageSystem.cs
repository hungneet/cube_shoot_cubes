
using Components;
using Unity.Collections;
using Unity.Entities;

public partial struct NameSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Allocator.Temp);
        foreach (var (dmg, hp, entity) in SystemAPI.Query<RefRO<Damage>, RefRW<HPComponent>>().WithEntityAccess())
        {
            hp.ValueRW.health -= dmg.ValueRO.Value;
            ecb.RemoveComponent<Damage>(entity);
        }
        ecb.Playback(state.EntityManager);
    }
}