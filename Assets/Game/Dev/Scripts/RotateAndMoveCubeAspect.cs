using Unity.Entities;
using Unity.Transforms;

public readonly partial struct RotateAndMoveCubeAspect : IAspect{

  // public readonly RefRO<RotatingCube> rotatingCube;
  public readonly RefRW<LocalTransform> localTransform;
  public readonly RefRW<RotateSpeed>    rotateSpeed;
  public readonly RefRW<Movement>       movement;

  public void MoveAndRotate(float deltaTime){

    var targetLocalTransform = localTransform.ValueRO;
    
    localTransform.ValueRW = targetLocalTransform.RotateY(rotateSpeed.ValueRO.value * deltaTime);
    localTransform.ValueRW = targetLocalTransform.Translate(movement.ValueRO.movementVector * deltaTime);

  }

}