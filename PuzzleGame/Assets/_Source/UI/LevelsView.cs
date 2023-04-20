using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelsView : MonoBehaviour
    {
        [SerializeField] private Button _levelsBackButton;
        [SerializeField] private Button _level1Button;
        [SerializeField] private Game _game;

        [SerializeField] private UISwitcher _uiSwitcher;
        [SerializeField] private GameObject _mainMenuPanel;

        private void Start()
        {
            Bind();
        }

        private void Bind()
        {
            _levelsBackButton.onClick.AddListener(() => _uiSwitcher.SetActivePanel(_mainMenuPanel));
            _level1Button.onClick.AddListener(() => _game.GoToFirstLevel());
        }

    }

}
