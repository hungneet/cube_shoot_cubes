using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

/*public partial struct MovingJob:IJobEntity
{
    //void Execute (ref )
}*/
public partial struct UserMovement : ISystem
{

    void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<StartGameCommand>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        //var world = state.World.Unmanaged;
        float deltaTime = SystemAPI.Time.DeltaTime;
        foreach (var (transform, user) in SystemAPI.Query<RefRW<LocalTransform>, RefRW<User>>())
        {

            float speed = 15f;
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
