
using Unity.Entities;
using Unity.Rendering;
using UnityEngine;

namespace Authoring
{
	public class MeshAuthoring : MonoBehaviour
	{
        public Mesh MeshID;

        public Material MaterialID;
        public class MeshComponentBaker : Baker<MeshAuthoring>
		{
			public override void Bake(MeshAuthoring authoring)
			{
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                var hybirdRender = World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<Entities​Graphics​System>();
                AddComponent(entity, new MeshComponent
                {
                    meshID = hybirdRender.RegisterMesh(authoring.MeshID),
                    materialID = hybirdRender.RegisterMaterial(authoring.MaterialID)
                });
            }
		}
	}
}




