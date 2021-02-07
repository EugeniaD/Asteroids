using UnityEngine;

namespace Assets.Scripts.Settings
{

  [CreateAssetMenu(menuName = "Entities/Settings/Boundaries", fileName = "BoundariesData")]
  public class HaveBoundaries : ScriptableObject
  {
    [SerializeField] private float _boundaryRadius = 0.5f;
    public float BoundaryRadius => _boundaryRadius;
  }
}
