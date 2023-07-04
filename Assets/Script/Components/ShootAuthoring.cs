
using Components;
using Unity.Entities;
using UnityEngine;
namespace Authoring
{
	public class ShootAuthoring : MonoBehaviour
	{
		public GameObject Prefab;
		public class ShootBaker : Baker<ShootAuthoring>
		{
			public override void Bake(ShootAuthoring authoring)
			{
				var entity = GetEntity(TransformUsageFlags.Dynamic);
				AddComponent(entity, new ShootComponent
				{
					prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic)
				});
			}
		}
	}
}

