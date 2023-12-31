using UnityEngine;
using static Enums;

namespace Game.Road
{
   public class DirectionOnTile : MonoBehaviour
   {
      public StartFinish StartOrFinish;
      public SideTile SideTile;
      public NumberOfWay NumberOfWay;
      private DirectionOnTile _connectionTile;

      public void SetConnection(DirectionOnTile tile)
      {
         _connectionTile = tile;
      }
   }
}
