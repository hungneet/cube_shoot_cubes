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
        foreach (var (transform,rotate) in SystemAPI.Query<RefRW<LocalTransform>,RefRW<Rotate>>()) {
            
            if(Mathf.Abs(transform.ValueRW.Position.x )> 25 )
            {
                rotate.ValueRW.speed = -rotate.ValueRW.speed;
            }
            transform.ValueRW.Position = new Unity.Mathematics.float3
            {
                x = transform.ValueRW.Position.x + rotate.ValueRO.speed * deltaTime,
                y = transform.ValueRW.Position.y,
                z = transform.ValueRW.Position.z
            };
       


        }
    }
}
