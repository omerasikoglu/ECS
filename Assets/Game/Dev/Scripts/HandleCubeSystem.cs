using Unity.Entities;

public partial struct HandleCubeSystem : ISystem{

  public void OnUpdate(ref SystemState state){
    foreach (var aspect in SystemAPI.Query<RotateAndMoveCubeAspect>()){

      aspect.MoveAndRotate(SystemAPI.Time.DeltaTime);

    }

  }

}