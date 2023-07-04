/*
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Systems
{
	public partial struct EnemySystem : ISystem
	{
        void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<StartGameCommand>();
        }
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;

            foreach (var (enemy, transform, e) in SystemAPI.Query<RefRW<EnemyComponent>, RefRW<LocalTransform>>().WithEntityAccess())
            {
                if (enemy.ValueRW.timer < enemy.ValueRW.spawnRate)
                {
                    enemy.ValueRW.timer += deltaTime;
                }
                else
                {
                    Entity bulletspawn = enemy.ValueRW.preFab;
                    state.EntityManager.SetComponentData(bulletspawn, new LocalTransform
                    {
                        Position = transform.ValueRW.Position,

                        Scale = 0.3f
                    });
                    state.EntityManager.Instantiate(bulletspawn);
                    enemy.ValueRW.timer = 0;

                }
            }
        }
    }
}

*/