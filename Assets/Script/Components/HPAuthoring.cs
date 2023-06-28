
using Components;
using Unity.Entities;
using UnityEngine;
namespace Authoring
{
	public class HPAuthoring : MonoBehaviour
	{
		public float Health = 2f;
		public class ComponentBaker : Baker<HPAuthoring>
		{
			public override void Bake(HPAuthoring authoring)
			{
				var entity = GetEntity(TransformUsageFlags.Dynamic);
				AddComponent(entity, new HPComponent {health = authoring.Health });
			}
		}
	}
}

