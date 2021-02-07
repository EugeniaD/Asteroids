using UnityEngine;

namespace Assets.Scripts.Move
{
  public class EnemyFacePlayer: IFacePlayer
  {
    private readonly NPCRotation _npcRotation;

    public EnemyFacePlayer(Transform transform, float rotationSpeed)
    {
      _npcRotation = new NPCRotation(transform, rotationSpeed);
    }

    public void Face(Transform target)
    {
      _npcRotation.Rotate(target.position);
    }
  }
}