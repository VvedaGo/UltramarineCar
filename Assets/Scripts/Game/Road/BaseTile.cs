using UnityEngine;

namespace Game.Road
{
  public class BaseTile : MonoBehaviour
  {
    public DirectionOnTile Start;
    public DirectionOnTile Finish;

    public void RotateTile(Vector3 rotationAngle)
    {
      transform.eulerAngles += rotationAngle;
      if (Start != null)
      {
        Start.SideTile = Start.SideTile.GetNextSideAfterRotate();
      }
      Finish.SideTile = Finish.SideTile.GetNextSideAfterRotate();
    }
  }
}
