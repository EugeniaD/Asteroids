using Assets.Scripts.Move;
using UnityEngine;

namespace Assets.Scripts.Entities
{
  public class Enemy : MonoBehaviour
  {
    [SerializeField]
    public float RotationSpeed = 240;
    [SerializeField]
    public float MaxSpeed = 2;
    private IEntityMovement _movement;
    private IFacePlayer _facePlayer;
    private Transform _player;

    private void Start()
    {
      _movement = new NPCMoveForward(MaxSpeed, transform);
      _facePlayer = new EnemyFacePlayer(transform, RotationSpeed);
    }

    private void Update()
    {
      _player = FindPlayer.Find(_player);
      if (_player == null) return;
      _facePlayer.Face(_player);
      _movement.Tick();
    }
  }
}
