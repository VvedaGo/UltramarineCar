using UnityEngine;

namespace Game.Road
{
   public class ZoneDirectionSetter : MonoBehaviour
   {
      [SerializeField] private Enums.DirectionRotate _directionToRotate;
      public Enums.DirectionRotate GetRotation => _directionToRotate;
   }
}
