using UnityEngine;

namespace Infrastructure
{
    public class UiGameFactory : IService
    {
        private readonly AssetProvider _assetProvider;

        public UiGameFactory(AssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public MenuHud CreateMenuHud()
        {
            MenuHud menuHud = Object.Instantiate(_assetProvider.GetMenuHud());
            return menuHud;
        }
    }
}