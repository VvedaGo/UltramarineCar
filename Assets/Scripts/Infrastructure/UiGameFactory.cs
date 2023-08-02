using Game;
using UnityEngine;

namespace Infrastructure
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
            menuHud.SetSceneLoader(_sceneLoader);
            return menuHud;
        }
    }
}