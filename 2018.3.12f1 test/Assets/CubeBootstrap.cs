using Assets;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class CubeBootstrap : MonoBehaviour
{
    public Mesh mesh;
    public Material material;

    public Vector3 spawnPos = new Vector3(5.3f, 0, -4.4f);

    void Start()
    {
        EntityManager mgr = World.Active.GetOrCreateManager<EntityManager>();
        EntityArchetype archeType = mgr.CreateArchetype(typeof(RenderMesh), typeof(Position), typeof(Rotation), typeof(LocalToWorld), typeof(VisibleLocalToWorld));
        RenderMesh shared = new RenderMesh { mesh = mesh, material = material, castShadows = UnityEngine.Rendering.ShadowCastingMode.Off, layer = 0, receiveShadows = false, subMesh = 0 };


        Entity cube = mgr.CreateEntity(archeType);
        mgr.SetComponentData(cube, new Position { Value = spawnPos });
        mgr.SetSharedComponentData(cube, shared);

        cube = mgr.CreateEntity(archeType);
        mgr.SetComponentData(cube, new Position { Value = spawnPos + new Vector3(0, 3f, 0) });

        mgr.SetComponentData(cube, new Rotation { Value = Quaternion.identity });
        mgr.SetSharedComponentData(cube, shared);
        mgr.AddComponent(cube, typeof(RotateComp));
        mgr.SetComponentData(cube, new RotateComp { Value = 1f });
    }
}
