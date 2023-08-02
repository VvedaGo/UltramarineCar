using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Setting : MonoBehaviour
    {
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Slider _soundsSlider;
        private SettingData _settingsData;

        public void LoadSetting(SettingData settingData)
        {
            _settingsData = settingData;
        }

        public void OpenMenu()
        {
            gameObject.SetActive(true);
        }

        public void ValueChanged()
        {
            _settingsData.MusicVolume = _musicSlider.value;
            _settingsData.SoundVolume = _soundsSlider.value;
        }
        public void CloseMenu()
        {
            gameObject.SetActive(false);
            //todo:Save data
        }
    }
}