using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial struct CubeRotateSystem : ISystem{

  public void OnUpdate(ref SystemState state){
    foreach (var (localTrnasform, rotateSpeed) in 
             SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotateSpeed>>()){
      localTrnasform.ValueRW = localTrnasform.ValueRO.
        RotateY(rotateSpeed.ValueRO.value * SystemAPI.Time.DeltaTime);
    }
  }
}