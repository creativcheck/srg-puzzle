using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterSystem;
using UnityEngine.SceneManagement;

namespace Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private int _thisLevelID, _nextLevelID, _mainMenuID;

        [SerializeField] private CharacterInput _inputListener;

        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void Continue()
        {
            Time.timeScale = 1;
        }

        public void RestartLevel()
        {
            Continue();
            _inputListener?.Expose();
            SceneManager.LoadScene(_thisLevelID);
        }

        public void NextLevel()
        {
            Continue();
            _inputListener?.Expose();
            SceneManager.LoadScene(_nextLevelID);
        }

        public void GoToMainMenu()
        {
            Continue();
            _inputListener?.Expose();
            SceneManager.LoadScene(_mainMenuID);
        }

        public void GoToFirstLevel()
        {
            Continue();
            SceneManager.LoadScene(_nextLevelID);
        }
    }
}

