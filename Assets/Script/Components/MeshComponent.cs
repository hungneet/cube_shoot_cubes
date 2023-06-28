using Unity.Entities;
using UnityEngine.Rendering;

public partial struct MeshComponent : IComponentData
{
    public BatchMaterialID materialID;
    public BatchMeshID meshID;


}
