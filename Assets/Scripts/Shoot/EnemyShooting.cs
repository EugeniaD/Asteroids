using UnityEngine;

namespace Assets.Scripts.Shoot
{
  public class EnemyShooting : MonoBehaviour
  {
    public float FireDelay = 1;
    public float CooldownTimer = 2;
    public GameObject BulletPrefab;
    private Transform _player;
    private int _bulletLayer;
    private int _distanceToPlayer = 4;

    void Start()
    {
      _bulletLayer = gameObject.layer;
    }

    void Update()
    {
      FindPlayer();

      CooldownTimer -= Time.deltaTime;
      if (CooldownTimer <= 0 && _player != null && Vector3.Distance(transform.position, _player.position) < _distanceToPlayer)
      {
        CooldownTimer = FireDelay;
        var bulletGO = (GameObject)Instantiate(BulletPrefab, transform.position, transform.rotation);
        bulletGO.layer = _bulletLayer;
      }
    }

    private void FindPlayer()
    {
      if (_player == null)
      {
        GameObject go = GameObject.FindWithTag("Player");

        if (go != null)
        {
          _player = go.transform;
        }
      }
    }
  }
}