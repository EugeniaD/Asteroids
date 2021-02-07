using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Damage
{
  // todo think about interfaces
  public class AsteroidDamageHandler : MonoBehaviour
  {
    public int Health = 1;
    public int FragmentsNum;
    public float InvulnPeriod = 0;
    private float _invulnTimer = 0;
    private int _correctLayer;
    private SpriteRenderer _spriteRend;
    public GameObject NewAsteroid;
    public AudioClip Explosion;


    void Start()
    {
      _correctLayer = gameObject.layer;
      _spriteRend = GetComponent<SpriteRenderer>();

      if (_spriteRend == null)
      {
        _spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

        if (_spriteRend == null)
        {
          Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer.");
        }
      }
    }

    void OnTriggerEnter2D()
    {
      Health--;
      ScoreManager.Score++;

      if (InvulnPeriod > 0)
      {
        _invulnTimer = InvulnPeriod;
        gameObject.layer = 10;
      }
    }

    void Update()
    {
      if (_invulnTimer > 0)
      {
        _invulnTimer -= Time.deltaTime;

        if (_invulnTimer <= 0)
        {
          gameObject.layer = _correctLayer;
          if (_spriteRend != null)
          {
            _spriteRend.enabled = true;
          }
        }
        else
        {
          if (_spriteRend != null)
          {
            _spriteRend.enabled = !_spriteRend.enabled;
          }
        }
      }

      if (Health <= 0)
      {
        AudioSource.PlayClipAtPoint(Explosion, transform.position, 1.5f);
        FragmentsAppear(NewAsteroid, FragmentsNum);
        Die();
      }
    }
    private void Die()
    {
      Destroy(gameObject);
    }

    private void FragmentsAppear(GameObject o, int fragmentsNum)
    {
      for (var i = 0; i <= fragmentsNum; i++)
      {
        Instantiate(o, gameObject.transform.position, Quaternion.identity);
      }
    }
  }
}
