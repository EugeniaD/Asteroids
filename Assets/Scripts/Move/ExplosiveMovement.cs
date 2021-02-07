using UnityEngine;

namespace Assets.Scripts.Move
{
  public class ExplosiveMovement : MonoBehaviour
  {
    private readonly float _maxSpeed = 1f;
    private float _xPos;
    private float _yPos;

    private void Start()
    {
      _xPos = Random.Range(-10f, 10f);
      _yPos = Random.Range(-10f, 10f);
    }

    private void Update()
    {
      var position = transform.position;
      var aroundPlayerPos = new Vector3(position.x + _xPos, position.y + _yPos, position.z);

      var step = _maxSpeed * Time.deltaTime;
      transform.position = Vector3.MoveTowards(transform.position, aroundPlayerPos, step);
    }
  }
}
