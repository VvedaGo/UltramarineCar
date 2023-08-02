using Game;
using UnityEngine;

public class AssetProvider : IService
{
    public MenuHud GetMenuHud()
    {
        return Resources.Load<MenuHud>(AssetPath.MenuHudPath);
    }
}