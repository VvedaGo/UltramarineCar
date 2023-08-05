namespace Infrastructure.Services
{
    public interface ISaveLoadService : IService
    {
        void Save();
        void Load();
    }
}