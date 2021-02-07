using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
  public class ScoreManager : MonoBehaviour
  {
    [HideInInspector] 
    public static int Score;
    public Text ScoreText;

    void Start()
    {
      UpdateScore();
    }

    void Update()
    {
      UpdateScore();
    }

    private void UpdateScore()
    {
      ScoreText.text = $"Score: {Score}";
    }
  }
}
