using UnityEngine;

namespace Assets.Scripts.Move
{
  public class NPCMoveForward: IEntityMovement
  {
    private readonly float _maxSpeed;
    private Transform _transform;

    public NPCMoveForward(float maxSpeed , Transform transform)
    {
      _maxSpeed = maxSpeed;
      _transform = transform;
    }

    public void Tick()
    {
      _transform.position += _transform.rotation * new Vector3(0, _maxSpeed * Time.deltaTime, 0);
    }
  }
}
