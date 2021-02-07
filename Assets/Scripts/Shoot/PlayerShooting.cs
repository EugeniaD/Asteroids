using UnityEngine;

namespace Assets.Scripts.Shoot
{
  public class PlayerShooting : MonoBehaviour
  {
    public GameObject BulletPrefab;
    public float FireDelay = 0.2f;
    private int _bulletLayer;
    public float CooldownTimer = 0;
    void Start()
    {
      _bulletLayer = gameObject.layer;
    }


    void Update()
    {
      CooldownTimer -= Time.deltaTime;
      if (Input.GetButton("Fire1") && CooldownTimer <= 0)
      {
        CooldownTimer = FireDelay;
        var bulletGO = (GameObject)Instantiate(BulletPrefab, transform.position, transform.rotation);
        bulletGO.layer = _bulletLayer;
      }
    }
  }
}
