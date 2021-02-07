using UnityEngine;

namespace Assets.Scripts.Damage
{
  public class SelfDestruct : MonoBehaviour
  {
    private float _timer = 10f;
    private Renderer _renderer;

    void Start()
    {
      _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
      if (!_renderer.isVisible)
      {
        _timer -= Time.deltaTime;
        if (_timer <= 0) Destroy(gameObject);
      }
    }
  }
}