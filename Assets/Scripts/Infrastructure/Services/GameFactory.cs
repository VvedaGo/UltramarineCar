namespace Infrastructure.Services
{
    public class GameFactory:IService
    {
        private readonly AssetProvider _assetProvider;

        public GameFactory(AssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
    }
}