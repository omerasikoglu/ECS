using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

public partial class SpawnCubesSystem : SystemBase{

  protected override void OnCreate(){
    RequireForUpdate<SpawnCubesConfig>();
  }

  protected override void OnUpdate(){
    Enabled = false;

    SpawnCubesConfig spawnCubesConfig = SystemAPI.GetSingleton<SpawnCubesConfig>();

    for (int i = 0; i < spawnCubesConfig.spawnAmount; i++){
      Entity spawnedEntity = EntityManager.Instantiate(spawnCubesConfig.cubePrefabEntity);

      float x = Random.Range(-10f, 5f);
      float y = 0.6f;
      float z = Random.Range(-4f, 7f);

      var newPosition = new float3(x, y, z);
      var newLocalTransform = new LocalTransform { Position = newPosition, Scale = 1f, Rotation = Quaternion.identity};
     
      SystemAPI.SetComponent(spawnedEntity, newLocalTransform);
      // EntityManager.SetComponentData(spawnedEntity, newLocalTransform);
    }

  }
}