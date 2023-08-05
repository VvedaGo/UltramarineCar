using Game;
using Game.Car;
using Game.Road;
using StaticData;
using Ui;
using UnityEngine;

namespace Infrastructure.Services
{
    public class AssetProvider : IService
    {
        public MenuHud GetMenuHud() 
            => Resources.Load<MenuHud>(AssetPath.MenuHudPath);

        public GameHud GetGameHud() 
            => Resources.Load<GameHud>(AssetPath.GameHudPath);

        public Car GetCar() 
            => Resources.Load<Car>(AssetPath.CarPath);

        public StartBaseTile GetStartTile() 
            => Resources.Load<TilesData>(AssetPath.TileStorage).StartTile;

        public BaseTile[] GetTilesStorage() 
            => Resources.Load<TilesData>(AssetPath.TileStorage).Tiles;
    }
}