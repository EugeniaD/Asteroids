using UnityEngine;

namespace Assets.Scripts.Move
{
  public static class FindPlayer
  {
    public static Transform Find(Transform player)
    {
      if (player == null)
      {
        var go = GameObject.FindWithTag("Player");
        if (go != null)
        {
          player = go.transform;
        }
      }
      return player;
    }
  }
}
