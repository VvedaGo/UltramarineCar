using Game;
using Ui;
using UnityEngine;

namespace Infrastructure.Services
{
    public class UiGameFactory : IService
    {
        private readonly AssetProvider _assetProvider;
        private readonly SceneLoader _sceneLoader;

        public UiGameFactory(AssetProvider assetProvider,SceneLoader sceneLoader)
        {
            _assetProvider = assetProvider;
            _sceneLoader = sceneLoader;
        }

        public MenuHud CreateMenuHud()
        {
            MenuHud menuHud = Object.Instantiate(_assetProvider.GetMenuHud());
            return menuHud;
        }

        public GameHud CreateGameHud()
        {
            GameHud menuHud = Object.Instantiate(_assetProvider.GetGameHud());
            return menuHud;
        }
    }
}