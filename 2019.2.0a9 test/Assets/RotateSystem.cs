using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Assets
{
    public class RotateSystem : ComponentSystem
    {
        EntityQuery query;

        protected override void OnCreateManager()
        {
            base.OnCreateManager();
            query = GetEntityQuery(ComponentType.ReadOnly<RotateComp>(), typeof(Rotation));
        }

        protected override void OnUpdate()
        {
            ComponentDataFromEntity<Rotation> rotations = GetComponentDataFromEntity<Rotation>();
            ComponentDataFromEntity<RotateComp> rotComps = GetComponentDataFromEntity<RotateComp>();
            using (NativeArray<Entity> entities = query.ToEntityArray(Allocator.TempJob))
            {
                for (int i = 0; i < entities.Length; i++)
                {
                    Entity e = entities[i];
                    quaternion rot = rotations[e].Value;
                    rot = Quaternion.Euler(0, rotComps[e].Value, 0) * rot;
                    rotations[e] = new Rotation { Value = rot };
                }
            }
        }
    }
}
