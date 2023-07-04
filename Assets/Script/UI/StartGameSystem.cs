using Unity.Entities;
using UnityEngine;

public partial struct StartGameSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<StartGameCommand>();
    }

    public void OnUpdate(ref SystemState state)
    {
        //new StartGameCommandListenerJob().Schedule();

        state.Enabled = false;
    }
}

