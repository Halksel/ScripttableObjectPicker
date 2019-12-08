using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class OneCube : MonoBehaviour
{
    void Start()
    {
        CreateCube();
    }

    void CreateCube()
    {
        
        var manager = World.DefaultGameObjectInjectionWorld.EntityManager;
        var archetype = manager.CreateArchetype(
            ComponentType.ReadWrite<LocalToWorld>(), 
            ComponentType.ReadWrite<Translation>(),
            ComponentType.ReadOnly<RenderMesh>());
        // 上記の Components を持つ Entity を作成
        var entity = manager.CreateEntity(archetype);
        // Entity の Component の値をセット（位置）
        manager.SetComponentData(entity, new Translation() { Value = new float3(0, 1, 0) });

        // キューブオブジェクトの作成
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        // Entity の Component の値をセット（描画メッシュ）
        manager.SetSharedComponentData(entity, new RenderMesh()
        {
            mesh = cube.GetComponent<MeshFilter>().sharedMesh,
            material = cube.GetComponent<MeshRenderer>().sharedMaterial,
            subMesh = 0,
            castShadows = UnityEngine.Rendering.ShadowCastingMode.Off,
            receiveShadows = false
        });

        // キューブオブジェクトの削除
        Destroy(cube);
    }
}
