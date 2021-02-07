using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
  public class UIManager : MonoBehaviour
  {
    private GameObject[] pauseObjects;

    private void Awake()
    {
      Time.timeScale = 1;
      pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
      HidePaused();
    }

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.P))
      {
        if (Time.timeScale == 1)
        {
          Time.timeScale = 0;
          ShowPaused();
        }
        else if (Time.timeScale == 0)
        {
          Debug.Log("high");
          Time.timeScale = 1;
          HidePaused();
        }
      }

      if (Input.GetKey("escape"))
      {
        Close();
      }
    }


    public void Reload()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      ScoreManager.Score = 0;
    }

    public void PauseControl()
    {
      if (Time.timeScale == 1)
      {
        Time.timeScale = 0;
        ShowPaused();
      }
      else if (Time.timeScale == 0)
      {
        Time.timeScale = 1;
        HidePaused();
      }
    }

    public void ShowPaused()
    {
      foreach (var g in pauseObjects) g.SetActive(true);
    }

    public void HidePaused()
    {
      foreach (var g in pauseObjects) g.SetActive(false);
    }

  
    public void LoadLevel(string level)
    {
      SceneManager.LoadScene(level);
      // todo fix play button
    }

    private void Close()
    {
      Application.Quit();
    }
  }
}
