using Game;

namespace Infrastructure
{
    public class WorldData:IService
    {
        public SettingData Setting;
        public PlayerProgress PlayerProgress;
        public WorldData()
        {
            Setting = new SettingData();
            PlayerProgress=new PlayerProgress();
        }
    }
}