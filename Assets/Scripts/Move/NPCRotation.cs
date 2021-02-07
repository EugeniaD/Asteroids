using UnityEngine;

namespace Assets.Scripts.Move
{
  public class NPCRotation
  {
    private readonly Transform _transform;
    private readonly float _rotationSpeed;

    public NPCRotation(Transform transform, float rotationSpeed)
    {
      _transform = transform;
      _rotationSpeed = rotationSpeed;
    }
    public void Rotate(Vector3 target)
    {
      var direction = target - _transform.position;
      direction.Normalize();
      var zAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
      var desiredRot = Quaternion.Euler(0, 0, zAngle);
      _transform.rotation = Quaternion.RotateTowards(_transform.rotation, desiredRot, _rotationSpeed * Time.deltaTime);
    }
  }
}
