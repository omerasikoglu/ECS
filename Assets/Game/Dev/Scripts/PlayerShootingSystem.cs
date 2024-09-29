using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial class PlayerShootingSystem :SystemBase{

  protected override void OnCreate(){
    RequireForUpdate<Player>();
  }

  protected override void OnUpdate(){

    if (!Input.GetKeyDown(KeyCode.Space)) return;

    SpawnCubesConfig spawnCubesConfig = SystemAPI.GetSingleton<SpawnCubesConfig>();

    foreach (var localTransform in SystemAPI.Query<RefRO<LocalTransform>>()){
      Entity spawnedEntity = EntityManager.Instantiate(spawnCubesConfig.cubePrefabEntity);

      float x = Random.Range(-10f, 5f);
      float y = 0.6f;
      float z = Random.Range(-4f, 7f);

      var newPosition       = localTransform.ValueRO.Position;
      var newLocalTransform = new LocalTransform { Position = newPosition, Scale = 1f, Rotation = Quaternion.identity };

      SystemAPI.SetComponent(spawnedEntity, newLocalTransform);
    }
  }
}