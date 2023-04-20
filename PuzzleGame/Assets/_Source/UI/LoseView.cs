using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LoseView : MonoBehaviour
    {
        [SerializeField] private Button _restartButton, _mainMenuButton;
        [SerializeField] private Game _game;

        void Start()
        {
            Bind();
        }

        private void Bind()
        {
            gameObject.SetActive(false);

            _restartButton.onClick.AddListener(_game.RestartLevel);
            _mainMenuButton.onClick.AddListener(_game.GoToMainMenu);
        }

        public void DrawLosePanel()
        {
            gameObject.SetActive(true);
            _game.Pause();
        }
    }

}
