using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WinView : MonoBehaviour
    {
        [SerializeField] private Game _game;
        [SerializeField] private Button _mainMenuButton, _nextLevelButton;

        private void Start()
        {
            Bind();
        }

        private void Bind()
        {
            gameObject.SetActive(false);

            _nextLevelButton.onClick.AddListener(_game.NextLevel);
            _mainMenuButton.onClick.AddListener(_game.GoToMainMenu);
        }

        public void DrawWinPanel()
        {
            gameObject.SetActive(true);
            _game.Pause();
        }
    }

}
