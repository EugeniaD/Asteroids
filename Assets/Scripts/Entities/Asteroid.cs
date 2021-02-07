using Assets.Scripts.Move;
using UnityEngine;

namespace Assets.Scripts.Entities
{
  public class Asteroid : MonoBehaviour
  {
    [SerializeField]
    public float RotationSpeed = 200;
    [SerializeField]
    public float MaxSpeed = 3;
    private IEntityMovement _movement;
    private IFacePlayer _facePlayer;
    private Transform _player;

    private void Start()
    {
      _movement = new NPCMoveForward(MaxSpeed, transform);
      _facePlayer = new AsteroidFacePlayer(transform, RotationSpeed);
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
