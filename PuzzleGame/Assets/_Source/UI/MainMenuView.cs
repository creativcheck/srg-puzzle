using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _levelsButton;
        [SerializeField] private Button _settingsButton;

        [SerializeField] private UISwitcher _uiSwitcher;
        [SerializeField] private GameObject _levelsPanel;
        [SerializeField] private GameObject _settingsPanel;

        private void Start()
        {
            Bind();
        }

        private void Bind()
        {
            _levelsButton.onClick.AddListener(() => _uiSwitcher.SetActivePanel(_levelsPanel));
            _settingsButton.onClick.AddListener(() => _uiSwitcher.SetActivePanel(_settingsPanel));

        }

    }
}
