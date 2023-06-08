using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.Profiling;


namespace BulletPool
{
    [RequireMatchingQueriesForUpdate]
    [BurstCompile]
    public partial struct BulletSpawnSystem: ISystem
    {

        public void OnUpdate(ref SystemState state)
        {
            var localToWorldLookup = SystemAPI.GetComponentLookup<LocalToWorld>();
            var ecb = new EntityCommandBuffer(Allocator.Temp);
            var world = state.World.Unmanaged;

            foreach (var (bulletpool, bulletLocalToWorld, transform, entity) in
                     SystemAPI.Query<RefRO<BulletPool>, RefRO<LocalToWorld>, RefRW<LocalTransform>>()
                         .WithEntityAccess())
            {
                transform.ValueRW.Position = new float3
                {
                    x = transform.ValueRW.Position.x,
                    y = transform.ValueRW.Position.y,
                    z = transform.ValueRW.Position.z
                };
                var bulletEntities =
                    CollectionHelper.CreateNativeArray<Entity, RewindableAllocator>(bulletpool.ValueRO.Count,
                        ref world.UpdateAllocator);
                
                state.EntityManager.Instantiate(bulletpool.ValueRO.Prefab, bulletEntities);
                
            }
        }
    }
}
