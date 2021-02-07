using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
  public class LivesManager : MonoBehaviour
  {
    [HideInInspector]
    public static int PlayerLives = 3;
    [HideInInspector]
    public static int PlayerDamage;
    public Text PlayerLivesText;
    public Text PlayerDamageText;
    public Text GameOverText;

    void Update()
    {
      PlayerDamageText.text = $"Damage: {PlayerDamage}";
      PlayerLivesText.text = $"Lives: {PlayerLives}";
      if (PlayerLives <= 0) GameOverText.text = ("Game Over!").ToUpper();
      // todo redo 
    }
  }
}
