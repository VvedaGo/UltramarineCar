using Game;
using UnityEngine;

namespace Infrastructure.Services
{
    public class GameFactory:IService
    {
        private readonly AssetProvider _assetProvider;
        private readonly BaseTile[] _tilesStorage;

        public GameFactory(AssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
            _tilesStorage = _assetProvider.GetTilesStorage();
        }

        public Car SpawnCar()
        {
            return Object.Instantiate(_assetProvider.GetCar());
        }

        public BaseTile SpawnStartTile()
        {
            return Object.Instantiate(_assetProvider.GetStartTile());
        }

        public BaseTile SpawnRandomTile()
        {
            return Object.Instantiate(_tilesStorage[Random.Range(0, _tilesStorage.Length)]);
        }
    }
}