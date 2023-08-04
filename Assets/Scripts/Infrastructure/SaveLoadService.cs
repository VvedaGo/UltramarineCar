using UnityEngine;

namespace Infrastructure
{
    public class SaveLoadService : ISaveLoadService
    {
        private WorldData _worldData;
        private string _playerProgress;

        public SaveLoadService(WorldData worldData)
        {
            _worldData = worldData;
        }
        public void Save()
        {
            string data = JsonUtility.ToJson(_worldData);
            _playerProgress = "PlayerProgress";
            PlayerPrefs.SetString(_playerProgress,data);
        }

        public void Load()
        {
            if (PlayerPrefs.HasKey(_playerProgress))
            {
                string data = PlayerPrefs.GetString(_playerProgress);
                _worldData = JsonUtility.FromJson<WorldData>(data);
            }
            else
            {
                _worldData=new WorldData();
            }
        }
    }
}