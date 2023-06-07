using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Burst;
using System;
using Unity.Transforms;


public partial struct CubeRotation : ISystem {
    [BurstCompile]
    public void OnUpdate(ref SystemState state) {
        float deltaTime = SystemAPI.Time.DeltaTime;
        foreach (var (tranform,rotate) in SystemAPI.Query<RefRW<LocalTransform>,RefRW<Rotate>>()) {
            
            if(Mathf.Abs(tranform.ValueRW.Position.x )> 25 )
            {
                rotate.ValueRW.speed = -rotate.ValueRW.speed;
            }
            tranform.ValueRW.Position = new Unity.Mathematics.float3
            {
                x = tranform.ValueRW.Position.x + rotate.ValueRO.speed * deltaTime,
                y = tranform.ValueRW.Position.y,
                z = tranform.ValueRW.Position.z
            };
       


        }
    }
}
