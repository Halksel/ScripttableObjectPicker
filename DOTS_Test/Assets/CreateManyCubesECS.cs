using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class CreateManyCubesECS : MonoBehaviour
{
    [SerializeField]
    int x;
    [SerializeField]
    int y;
    void Start()
    {
        CreateCubes();
    }

    void CreateCubes()
    {
        var manager = World.DefaultGameObjectInjectionWorld.EntityManager;
        // Entity が持つ Components を設計（Prefabとして）
        var archetype = manager.CreateArchetype(
            ComponentType.ReadOnly<Prefab>(),
            ComponentType.ReadWrite<LocalToWorld>(), 
            ComponentType.ReadWrite<Translation>(),
            ComponentType.ReadOnly<RenderMesh>());
        // 上記の Components を持つ Entity を作成
        var prefab = manager.CreateEntity(archetype);
        // Entity の Component の値をセット（位置）
        manager.SetComponentData(prefab, new Translation() { Value = new float3(0, 1, 0) });

        // キューブオブジェクトの作成
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        // Entity の Component の値をセット（描画メッシュ）
        manager.SetSharedComponentData(prefab, new RenderMesh()
        {
            mesh = cube.GetComponent<MeshFilter>().sharedMesh,
            material = cube.GetComponent<MeshRenderer>().sharedMaterial,
            subMesh = 0,
            castShadows = UnityEngine.Rendering.ShadowCastingMode.Off,
            receiveShadows = false
        });

        // キューブオブジェクトの削除
        Destroy(cube);

        const int SIDE = 100;
        using (NativeArray<Entity> entities = new NativeArray<Entity>(x * y, Allocator.Temp, NativeArrayOptions.UninitializedMemory))
        {
            // Prefab Entity をベースに 10000 個の Entity を作成
            manager.Instantiate(prefab, entities);
            // 平面に敷き詰めるように Translation を初期化
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    int index = i + j * x;
                    manager.SetComponentData(entities[index], new Translation
                    {
                        Value = new float3(i, 0, j)
                    });
                }
            }
        }
    }
}
