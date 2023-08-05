using Infrastructure.Services;

namespace StaticData
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