
using Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.UIElements;

namespace Systems
{
	public partial struct UserShootSystem: ISystem
	{
        [BurstCompile]
		public void OnUpdate(ref SystemState state)
		{   
            float deltaTime = SystemAPI.Time.DeltaTime;
			foreach (var (user,shoot,transform, e) in SystemAPI.Query<RefRW<User>, RefRO<ShootComponent>
				,RefRW<LocalTransform>>().WithEntityAccess())
			{
                if (user.ValueRW.timer < user.ValueRW.spawnRate)
                {
                    user.ValueRW.timer += deltaTime;
                }
                else
                {   UnityEngine.Debug.Log("shoot");
                    Entity bulletspawn = shoot.ValueRO.prefab;
                    state.EntityManager.SetComponentData(bulletspawn, new LocalTransform
                    {
                        Position = transform.ValueRW.Position,
                        Rotation =  quaternion.identity,
                        Scale = 0.5f
                    });
                    state.EntityManager.Instantiate(bulletspawn);
                    user.ValueRW.timer = 0;
                        
                }
            }
        }
	}
}

