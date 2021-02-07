using UnityEngine;

namespace Assets.Scripts.Appearance
{
  public class EnemyAppearance : MonoBehaviour
  {
    public GameObject[] SpawnObjects;
    public float NextEnemyTimer;
    public float AppearanceDistance = 15f;
    private readonly float _enemyRate = 3;
    private int _randomOption;
    private AppearEnemy _appearEnemy;
    void Start()
    {
      _appearEnemy = new AppearEnemy();
      _appearEnemy.Appear(transform, SpawnObjects[0], AppearanceDistance, _enemyRate, out NextEnemyTimer);
    }

    void Update()
    {
      _randomOption = Random.Range(0, SpawnObjects.Length);
      NextEnemyTimer -= Time.deltaTime;
      if (NextEnemyTimer <= 0)
        _appearEnemy.Appear(transform, SpawnObjects[_randomOption], AppearanceDistance, _enemyRate, out NextEnemyTimer);
    }
  }
}
