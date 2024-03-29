using System;
using CortexDeveloper.ECSMessages.Service;
using Samples.UserInterfaceExample;
using Unity.Entities;
using UnityEngine;

public class ESCSetUp : MonoBehaviour
{
    private static World _world;
    private SimulationSystemGroup _simulationSystemGroup;
    private LateSimulationSystemGroup _lateSimulationSystemGroup;

    private void Awake()
    {
        InitializeMessageBroadcaster();
        CreateSystems();
    }

    private void OnDestroy()
    {
        if (!_world.IsCreated)
            return;

        DisposeMessageBroadcaster();
        RemoveSystem();
    }

    private void InitializeMessageBroadcaster()
    {
        _world = World.DefaultGameObjectInjectionWorld;
        _simulationSystemGroup = _world.GetOrCreateSystemManaged<SimulationSystemGroup>();
        _lateSimulationSystemGroup = _world.GetOrCreateSystemManaged<LateSimulationSystemGroup>();

        MessageBroadcaster.InitializeInWorld(_world, _lateSimulationSystemGroup);
    }

    private void DisposeMessageBroadcaster()
    {
        MessageBroadcaster.DisposeFromWorld(_world);
    }

    private void CreateSystems()
    {
        /*_simulationSystemGroup.AddSystemToUpdateList(_world.CreateSystem<StartGameSystem>());
        _simulationSystemGroup.AddSystemToUpdateList(_world.CreateSystem<PauseGameSystem>());*/
    }

    private void RemoveSystem()
    {
        /*_simulationSystemGroup.RemoveSystemFromUpdateList(_world.GetExistingSystem<StartGameSystem>());
        _simulationSystemGroup.RemoveSystemFromUpdateList(_world.GetExistingSystem<PauseGameSystem>());*/
    }
}