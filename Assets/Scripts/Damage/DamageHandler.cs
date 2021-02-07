using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Damage
{
  public class DamageHandler : MonoBehaviour
  {
    public int Lives = 1;
    public float InvulnPeriod = 0;
    private float _invulnTimer = 0;
    private int _correctLayer;
    private SpriteRenderer spriteRend;
    public AudioClip Explosion;


    void Start()
    {
      if (gameObject.tag == "Player") LivesManager.PlayerDamage = Lives;
      _correctLayer = gameObject.layer;

      spriteRend = GetComponent<SpriteRenderer>();

      if (spriteRend == null)
      {
        spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

        if (spriteRend == null)
        {
          Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer.");
        }
      }
    }
  
    void OnTriggerEnter2D()
    {
      Lives--;

      if (gameObject.tag != "Player") ScoreManager.Score++;
      else LivesManager.PlayerDamage = Lives;

      if (InvulnPeriod > 0)
      {
        _invulnTimer = InvulnPeriod;
        gameObject.layer = 10;
      }
    }

    // todo add a blinking to the player 
    // todo get rid of ifs
    void Update()
    {
      if (_invulnTimer > 0)
      {
        _invulnTimer -= Time.deltaTime;

        if (_invulnTimer <= 0)
        {
          gameObject.layer = _correctLayer;
          if (spriteRend != null)
          {
            spriteRend.enabled = true;
          }
        }
        else
        {
          if (spriteRend != null)
          {
            spriteRend.enabled = !spriteRend.enabled;
          }
        }
      }

      if (Lives <= 0)
      {
        if (Explosion != null)
        {
          AudioSource.PlayClipAtPoint(Explosion, transform.position, 1.5f);
        }
        Die();
      }
    }

    void Die()
    {
      Destroy(gameObject);
    }
  }
}