using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct Movement : IComponentData{ // @formatter:off
  public float3 movementVector;
}

public class MovementAuthoring : MonoBehaviour{

  public class DummyBaker : Baker<MovementAuthoring>{

    public override void Bake(MovementAuthoring authoring){
      Entity entity = GetEntity(TransformUsageFlags.Dynamic);

      float x = UnityEngine.Random.Range(-1f, 1f);
      float y = UnityEngine.Random.Range(-1f, 1f);
      float z = UnityEngine.Random.Range(-1f, 1f);

      AddComponent(entity, new Movement {
        movementVector = new float3(x, y, z)
      });
    }
  }
}