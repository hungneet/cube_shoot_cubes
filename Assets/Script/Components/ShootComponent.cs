
using Unity.Entities;
using UnityEngine;

namespace Components
{
	public partial struct  ShootComponent: IComponentData
	{
		public Entity prefab;
	}
}
