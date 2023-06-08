using Unity.Entities;
using UnityEngine;

namespace BulletPool
{
    public class BulletPoolAuthoring : MonoBehaviour
    {
        public GameObject Prefab;
        public float InitialRadius;
        public int Count;

        class Baker : Baker<BulletPoolAuthoring>
        {
            public override void Bake(BulletPoolAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Renderable);
                AddComponent(entity, new BulletPool
                {
                    Prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic),
                    Count = authoring.Count,
                    InitialRadius = authoring.InitialRadius
                });
            }
        }
    }

    public struct BulletPool : IComponentData
    {
        public Entity Prefab;
        public float InitialRadius;
        public int Count;
    }
}