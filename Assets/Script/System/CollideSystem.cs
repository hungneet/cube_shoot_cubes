using System.Diagnostics;
using Unity.Collections;
using Unity.Entities;
using Unity.Physics;
using Unity.VisualScripting;
using UnityEngine;


namespace Systems
{
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    [UpdateAfter(typeof(SimulationSystemGroup))]
    public partial struct CollideSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EnemyComponent>();
            state.RequireForUpdate<Bullet>();
            state.RequireForUpdate<SimulationSingleton>();
        }

        public void OnUpdate(ref SystemState state)
        {
            var ecb = new EntityCommandBuffer(Allocator.TempJob);

            //var gameConfigEntity = SystemAPI.GetSingletonEntity<GameConfig>();
            //* Dependency is a way to make sure that the job is finished before the next job is started.
            state.Dependency = new JobCheckCollision
            {
                ecb = ecb,
                enemyLookup = state.GetComponentLookup<EnemyComponent>(),
                bulletLookup = state.GetComponentLookup<Bullet>(),
            }.Schedule(
                //* SimulationSingleton is a way to get the physics world.
                SystemAPI.GetSingleton<SimulationSingleton>(),
                state.Dependency
                );

            //* Complete is a way to make sure that the job is finished before the next job is started.
            state.Dependency.Complete();

            //* Playback is a way to play the command buffer. 
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }

    //* ITriggerEventsJob is a way to get the trigger event.
    internal struct JobCheckCollision : ITriggerEventsJob
    {
        //* EntityCommandBuffer is a way to create, delete, and modify entities from a job.
        public EntityCommandBuffer ecb { get; set; }

        //* When you want to passing a array of component, you need to use ComponentLookup
        public ComponentLookup<EnemyComponent> enemyLookup { get; set; }
        public ComponentLookup<Bullet> bulletLookup { get; set; }

        // public float _dame;

        public void Execute(TriggerEvent triggerEvent)
        {

            var isBulletHitEnemy = (bulletLookup.HasComponent(triggerEvent.EntityA) && enemyLookup.HasComponent(triggerEvent.EntityB)) || (bulletLookup.HasComponent(triggerEvent.EntityB) && enemyLookup.HasComponent(triggerEvent.EntityA));

            if (isBulletHitEnemy)
            {
                if (enemyLookup.HasComponent(triggerEvent.EntityA))
                {
                    
                    ecb.AddComponent(triggerEvent.EntityB, new Destroy { });
                    ecb.AddComponent(triggerEvent.EntityA, new Damage
                    {
                        Value = 1
                    });

                }
                if (enemyLookup.HasComponent(triggerEvent.EntityB))
                {
                    
                    ecb.AddComponent(triggerEvent.EntityA, new Destroy { });
                    ecb.AddComponent(triggerEvent.EntityB, new Damage
                    {
                        Value = 1
                    });

                }
            }
        }
    }
}

