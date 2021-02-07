using Assets.Scripts.Controls;
using Assets.Scripts.Move;
using Assets.Scripts.Settings;
using UnityEngine;

namespace Assets.Scripts.Entities
{
  public class Player : MonoBehaviour
  {
    [SerializeField]
    private HaveBoundaries _haveBoundaries;
    [SerializeField]
    public float RotationSpeed = 240;
    [SerializeField]
    public float MaxSpeed = 5;

    private IEntityMovement _movement;
    private PlayerInput _playerInput; 

    private void Awake()
    {
      _haveBoundaries = ScriptableObject.CreateInstance<HaveBoundaries>();
      _playerInput = new PlayerInput();
      _movement = new PlayerMovement(_playerInput, transform, _haveBoundaries, MaxSpeed, RotationSpeed);
    }

    private void Update()
    {
      _playerInput.ReadInput();
      _movement.Tick();
    }
  }
}
