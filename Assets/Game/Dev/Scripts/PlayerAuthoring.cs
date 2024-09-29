using Unity.Entities;
using UnityEngine;

public struct Player : IComponentData{
  
}

public class PlayerAuthoring : MonoBehaviour{

  public class DummyBaker : Baker<PlayerAuthoring>{

    public override void Bake(PlayerAuthoring authoring){
      Entity entity = GetEntity(TransformUsageFlags.Dynamic);
      AddComponent(entity, new Player());
    }
  }
  
  
}