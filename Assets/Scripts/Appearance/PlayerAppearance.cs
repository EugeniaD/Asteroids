using Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Appearance
{
  public class PlayerAppearance : MonoBehaviour
  {
    public GameObject PlayerPrefab;
    private GameObject _playerInstance;
    private float _reappearTimer;

    void Start()
    {
      Appear();
    }

    void Update()
    {
      if (_playerInstance == null && LivesManager.PlayerLives > 0)
      {
        _reappearTimer -= Time.deltaTime;
        if (_reappearTimer <= 0)
        {
          Appear();
          LivesManager.PlayerLives--;
        }
      }
    }

    private void Appear()
    {
      _reappearTimer = 1;
      _playerInstance = Instantiate(PlayerPrefab, transform.position, Quaternion.identity);
    }
  }
}
