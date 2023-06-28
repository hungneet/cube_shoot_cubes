
using System.Diagnostics;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

namespace Systems
{
	public partial struct LevelUpSystem : ISystem
	{
		public void OnUpdate(ref SystemState state)
		{
			foreach (var (spawner, e) in SystemAPI.Query<RefRW<ESpawn>>().WithEntityAccess())
			{
				var query = new EntityQueryBuilder(Allocator.Temp)
                    .WithAll<EnemyComponent>()
                    .WithAll<LocalTransform>()
                    .Build(ref state);
				UnityEngine.Debug.Log(query.CalculateEntityCount());

                if (query.CalculateEntityCount() == 0 && spawner.ValueRO.level <= spawner.ValueRO.maxLevel )
				{
					spawner.ValueRW.level += 1;	
					UnityEngine.Debug.Log("level" + spawner.ValueRW.level);
                }
			}
		}
	}
}

