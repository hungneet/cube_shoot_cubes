using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Burst;
using System;
using Unity.Transforms;
using Unity.Jobs;

[BurstCompile]
public partial struct BForwardJob : IJobEntity
{
    public float deltaTime;
    public float speed;
    //Ref: RW, in: RO
    void Execute( ref LocalTransform transform, in Bullet bl)
    {
        
        transform.Position.z += speed * deltaTime;
    }

}

public partial struct BulletForward : ISystem
{   


    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {   /*
        float deltaTime = SystemAPI.Time.DeltaTime;
        foreach (var (tranform, _ )in SystemAPI.Query<RefRW<LocalTransform>, RefRO<Bullet>>())
        { float speed = 10f;
           tranform.ValueRW.Position.z += speed * deltaTime;
           if (tranform.ValueRW.Position.z >= 8)
            {
                
            }
        }*/

        new BForwardJob { deltaTime = SystemAPI.Time.DeltaTime, speed = 10f }.Schedule();

    }
}
