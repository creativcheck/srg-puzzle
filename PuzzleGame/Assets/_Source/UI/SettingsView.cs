using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UI
{
    public class SettingsView : MonoBehaviour
    {
        [SerializeField] private Button _backButton;

        [SerializeField] private UISwitcher _uiSwitcher;
        [SerializeField] private GameObject _mainMenuPanel;

        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Slider _sfxSlider;

        [SerializeField] private AudioMixer _mixer;

        private const string MUSIC_VOLUME = "MUSIC_VOLUME";
        private const string SFX_VOLUME = "SFX_VOLUME";

        private void Awake()
        {
            Init();
            Bind();
        }
        
        private void OnDisable()
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME, _musicSlider.value);
            PlayerPrefs.SetFloat(SFX_VOLUME, _sfxSlider.value);
        }

        private void Init()
        {
            _musicSlider.value = PlayerPrefs.GetFloat(MUSIC_VOLUME, 1f);
            _sfxSlider.value = PlayerPrefs.GetFloat(SFX_VOLUME, 1f);

            SetMusicVolume(_musicSlider.value);
            SetSFXVolume(_sfxSlider.value);
        }

        private void Bind()
        {
            _backButton.onClick.AddListener(() => _uiSwitcher.SetActivePanel(_mainMenuPanel));

            _musicSlider.onValueChanged.AddListener(SetMusicVolume);
            _sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        }

        private void SetMusicVolume(float value)
        {
            _mixer.SetFloat(MUSIC_VOLUME, Mathf.Log10(value) * 20);
        }

        private void SetSFXVolume(float value)
        {
            _mixer.SetFloat(SFX_VOLUME, Mathf.Log10(value) * 20);
        }

    }

}
