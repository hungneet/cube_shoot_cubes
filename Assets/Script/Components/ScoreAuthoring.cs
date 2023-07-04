
using Components;
using Unity.Entities;
using UnityEngine;
namespace Authoring
{
	public class ScoreAuthoring : MonoBehaviour
	{ public int Score=0;
		public class ComponentBaker : Baker<ScoreAuthoring>
		{
			public override void Bake(ScoreAuthoring authoring)
			{
				var entity = GetEntity(TransformUsageFlags.Dynamic);
				AddComponent(entity, new ScoreComponent { score = authoring.Score});
			}
		}
	}
}

