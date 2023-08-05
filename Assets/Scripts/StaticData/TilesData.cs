using Game;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "Create TilesData", fileName = "TilesData", order = 0)]
    public class TilesData : ScriptableObject
    {
        public StartBaseTile StartTile;
        public BaseTile[] Tiles;
    }

}
