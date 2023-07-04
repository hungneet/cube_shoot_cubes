
using Components;
using Unity.Collections;
using Unity.Entities;

public partial struct DestroySystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
    }

    public void OnUpdate(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Allocator.Temp);

        foreach (var (_, entity) in SystemAPI.Query<RefRO<Destroy>>().WithEntityAccess())
        {
            ecb.DestroyEntity(entity);
            var score = SystemAPI.GetSingleton<ScoreComponent>();
            score.score += 5;
            SystemAPI.SetSingleton<ScoreComponent>(score);

        }

        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }

}