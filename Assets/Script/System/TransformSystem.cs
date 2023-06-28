
using Unity.Collections;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine.XR;

namespace Systems
{
	public partial struct TransformSystem : ISystem
	{
		public void OnUpdate(ref SystemState state)
		{
			foreach (var (mesh, meshinfo,tf, e) in SystemAPI.Query<RefRO<MeshComponent>, RefRW<MaterialMeshInfo>, RefRO<LocalTransform>>().WithEntityAccess())
			{
				//if abs of e.position.x > 25 change meshinfo.materialID else keep it

				meshinfo.ValueRW.MaterialID = mesh.ValueRO.materialID;
				meshinfo.ValueRW.MeshID = mesh.ValueRO.meshID;
			}
		}
	}
}

