using Assets.Scripts.Controls;
using Assets.Scripts.Settings;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Move
{
  public class PlayerMovement : IEntityMovement
  {
    private readonly PlayerInput _playerInput;
    private readonly Transform _transform;
    private readonly HaveBoundaries _haveBoundaries;
    private readonly float _maxSpeed;
    private readonly float _rotationSpeed;

    public PlayerMovement(PlayerInput playerInput, Transform transform, HaveBoundaries haveBoundaries, float maxSpeed, float rotationSpeed)
    {
      _playerInput = playerInput;
      _transform = transform;
      _haveBoundaries = haveBoundaries;
      _maxSpeed = maxSpeed;
      _rotationSpeed = rotationSpeed;
    }

    public void Tick()
    {
      _transform.Rotate(new Vector3(0, 0, _playerInput.Rotation * _rotationSpeed * Time.deltaTime));

      // todo get rid of if
      if (ScoreManager.Score >= 5)
      {
        _transform.Translate(new Vector3(0, _playerInput.Thrust * _maxSpeed * Time.deltaTime, 0));
      }

      _transform.position = StayInBoundaries(_transform.position);
    }

    private Vector3 StayInBoundaries(Vector3 pos)
    {
      var widthOrtho = Camera.main.orthographicSize * Screen.width / Screen.height;

      if (pos.y + _haveBoundaries.BoundaryRadius > Camera.main.orthographicSize)
        pos.y = Camera.main.orthographicSize - _haveBoundaries.BoundaryRadius;
      if (pos.y - _haveBoundaries.BoundaryRadius < -Camera.main.orthographicSize)
        pos.y = -Camera.main.orthographicSize + _haveBoundaries.BoundaryRadius;
      if (pos.x + _haveBoundaries.BoundaryRadius > widthOrtho)
        pos.x = widthOrtho - _haveBoundaries.BoundaryRadius;
      if (pos.x - _haveBoundaries.BoundaryRadius < -widthOrtho)
        pos.x = -widthOrtho + _haveBoundaries.BoundaryRadius;

      return pos;
    }
  }
}