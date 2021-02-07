using UnityEngine;

namespace Assets.Scripts.Appearance
{
  public class AppearEnemy
  {
    public float Appear( Transform transform, GameObject enemyPrefab, float appearanceDistance, float enemyRate, out float nextEntityTimer)
    {
      nextEntityTimer = enemyRate;
      enemyRate *= 0.8f;
      if (enemyRate < 2) enemyRate = 2;

      var offset = Random.onUnitSphere;
      offset.z = 0;
      offset = offset.normalized * appearanceDistance;
      Object.Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
      return enemyRate;
    }
  }
}
