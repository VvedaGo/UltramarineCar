using UnityEngine;

public class UiGameFactory : IService
{
    private readonly AssetProvider _assetProvider;

    public UiGameFactory(AssetProvider assetProvider)
    {
        _assetProvider = assetProvider;
    }

    public void CreateMenuHud()
    {
        MenuHud menuHud = Object.Instantiate(_assetProvider.GetMenuHud());
    }
}