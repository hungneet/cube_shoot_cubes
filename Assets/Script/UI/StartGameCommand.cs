using CortexDeveloper.ECSMessages.Components;
using Unity.Entities;

public struct StartGameCommand : IComponentData, IMessageComponent
{
    public bool start { get; set; }
}