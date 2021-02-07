using UnityEngine;

namespace Assets.Scripts.Controls
{
  public class PlayerInput
  {
    public float Rotation { get; private set; }
    public float Thrust { get; private set; }
    public void ReadInput()
    {
      Rotation = -Input.GetAxis("Horizontal");
      Thrust = Input.GetAxis("Vertical");
    }
  }
}
