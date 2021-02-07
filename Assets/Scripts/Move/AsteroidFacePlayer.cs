using UnityEngine;

namespace Assets.Scripts.Move
{
  public class AsteroidFacePlayer: IFacePlayer
  {
    private readonly Transform _transform;
    private readonly Vector3 _desiredPos;
    private readonly float _xPos;
    private readonly float _yPos;
    private readonly NPCRotation _npcRotation;

    public AsteroidFacePlayer( Transform transform, float rotationSpeed)
    {
      // todo get rid of 9
      _xPos = Random.Range(-9f, 9f);
      _yPos = Random.Range(-9f, 9f);
      _desiredPos = new Vector3(_xPos, _yPos, transform.position.z);
      _transform = transform;
      _npcRotation = new NPCRotation(transform, rotationSpeed);
    }


    public void Face(Transform target)
    {
      var aroundTarget = new Vector3(target.position.x + _xPos, target.position.y + _yPos, target.position.z);

      // todo get rid of 12
      if (Vector3.Distance(_transform.position, _desiredPos) >= 18f)
      {
        _npcRotation.Rotate(aroundTarget);
      }
    }
  }
}