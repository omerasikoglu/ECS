using UnityEngine;
using Unity.Entities;

public struct RotateSpeed : IComponentData{
  public float value;
}

public class RotateSpeedAuthoring : MonoBehaviour{

  public float value;

  class DummyBaker : Baker<RotateSpeedAuthoring>{

    public override void Bake(RotateSpeedAuthoring authoring){
      var entity = GetEntity(TransformUsageFlags.Dynamic);
      AddComponent(entity, new RotateSpeed { value = authoring.value });
    }
  }

}