namespace Infrastructure
{
    public interface ISaveLoadService : IService
    {
        void Save();
        void Load();
    }
}