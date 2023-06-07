using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Burst;
using System;
using Unity.Transforms;


public partial struct UserMovement : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;
        foreach (var (transform, rotate) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<User>>())
        { float speed = 5f;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.ValueRW.Position.z += deltaTime * speed;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.ValueRW.Position.z -= deltaTime * speed;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.ValueRW.Position.x -= deltaTime * speed;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.ValueRW.Position.x += deltaTime * speed;
            }
        }
    }
}
