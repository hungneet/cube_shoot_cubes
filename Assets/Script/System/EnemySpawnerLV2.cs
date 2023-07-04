using System.Drawing;
using System.Numerics;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using static UnityEngine.Rendering.DebugUI.Table;

public partial struct EnemySpawnerLV2 : ISystem
{
    void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<StartGameCommand>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var spawner = SystemAPI.GetSingletonRW<ESpawn>();
        if (spawner.ValueRO.level != 2) return;
        state.Enabled = false;
        var enemy = spawner.ValueRO.preFab;
        var ecb = new EntityCommandBuffer(Allocator.TempJob);

        float spacing = 1.5f; 
        int rows = 10;
        for (int row = 0; row < rows; row++)
        {
            int cols = rows - row;  // Number of columns in each row

            for (int col = 0; col < cols; col++)
            {
                // Calculate the position based on the current row and column
                float xPos = (col - (cols - 1) / 2.0f) * spacing;
                float yPos = row * spacing;

                // Instantiate the prefab at the calculated position
                var newEnemy = ecb.Instantiate(enemy);
                ecb.SetComponent(newEnemy, new LocalTransform
                {
                    Position = new float3(xPos,0f,yPos),
                    Rotation = quaternion.identity,
                    Scale = 1f
                });
            }
        }

        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}
