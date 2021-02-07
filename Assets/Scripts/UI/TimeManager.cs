using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
  public class TimeManager: MonoBehaviour
  {
    private float _time;
    public Text CurrentTimeText;

    void Update()
    {
      _time = Time.time;
      CurrentTimeText.text = $"Time: {_time:F}";
    }
  }
}
