using Assets.Scripts.Move;
using UnityEngine;

namespace Assets.Scripts.Entities
{
  public class Laser: MonoBehaviour
  {
    [SerializeField]
    public float _maxSpeed;
    private IEntityMovement _movement;

    private void Awake()
    {
      _movement = new NPCMoveForward(_maxSpeed, transform);
    }

    private void Update()
    {
      _movement.Tick();
    }
  }
}
