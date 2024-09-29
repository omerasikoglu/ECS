using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

public partial struct CubeRotateSystem : ISystem{

  public void OnCreate(ref SystemState state){
    state.RequireForUpdate<RotateSpeed>();
  }

  public void OnUpdate(ref SystemState state){
    foreach (var (localTransform, rotateSpeed) in
             SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotateSpeed>>().WithNone<Player>()){
      
      // functions
      
      var targetTrnasform = localTransform.ValueRO;
      targetTrnasform        = targetTrnasform.RotateY(rotateSpeed.ValueRO.value * SystemAPI.Time.DeltaTime);
      localTransform.ValueRW = targetTrnasform;
    }

    RotatingCubeJob rotatingCubeJob = new() { deltaTime = SystemAPI.Time.DeltaTime };

    rotatingCubeJob.Schedule();

  }

  [BurstCompile][WithNone(typeof(Player))]
  public partial struct RotatingCubeJob : IJobEntity{
    public float deltaTime;

    void Execute(ref LocalTransform localTransform, in RotateSpeed rotateSpeed){

      // float power = UnityEngine.Random.Range(1f, 8f);
      float power = 2f;
      localTransform = localTransform.RotateY(rotateSpeed.value * deltaTime * power);
    }

  }
}