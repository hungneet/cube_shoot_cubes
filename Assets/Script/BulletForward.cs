using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Burst;
using System;
using Unity.Transforms;


public partial struct BulletForward : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;
        foreach (var (tranform, _ )in SystemAPI.Query<RefRW<LocalTransform>, RefRO<Bullet>>())
        { float speed = 10f;
           tranform.ValueRW.Position.z += speed * deltaTime;
           if (tranform.ValueRW.Position.z >= 8)
            {
                
            }
        }

    }
}
