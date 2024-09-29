using Unity.Entities;
using UnityEngine;

public class SpawnCubesConfigAuthoring : MonoBehaviour{

  public GameObject cubePrefab;
  public int        spawnAmount;

  public class DummyBaker : Baker<SpawnCubesConfigAuthoring>{

    public override void Bake(SpawnCubesConfigAuthoring authoring){
      Entity entity = GetEntity(TransformUsageFlags.None);
      
      AddComponent(entity, new SpawnCubesConfig {
        cubePrefabEntity = GetEntity(authoring.cubePrefab, TransformUsageFlags.Dynamic),
        spawnAmount = authoring.spawnAmount
      });
    }
  }
  
}

public struct SpawnCubesConfig : IComponentData{
  public Entity cubePrefabEntity;
  public int    spawnAmount;
}