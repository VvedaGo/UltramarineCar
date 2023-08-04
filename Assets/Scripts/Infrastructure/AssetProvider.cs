using Game;
using StaticData;
using UnityEngine;

namespace Infrastructure
{
    public class AssetProvider : IService
    {
        public MenuHud GetMenuHud() 
            => Resources.Load<MenuHud>(AssetPath.MenuHudPath);

        public GameHud GetGameHud() 
            => Resources.Load<GameHud>(AssetPath.GameHudPath);

        public Car GetCar() 
            => Resources.Load<Car>(AssetPath.CarPath);

        public BaseTile GetStartTile() 
            => Resources.Load<TilesData>(AssetPath.TileStorage).StartTile;

        public BaseTile[] GetTilesStorage() 
            => Resources.Load<TilesData>(AssetPath.TileStorage).Tiles;
    }
}