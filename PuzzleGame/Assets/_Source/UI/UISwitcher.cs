using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UISwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject _startPanel;

        private GameObject _activePanel;

        private void Start()
        {
            _activePanel = _startPanel;
            SetActivePanel(_activePanel);
        }

        public void SetActivePanel(GameObject panel)
        {
            _activePanel?.SetActive(false);
            _activePanel = panel;
            _activePanel.SetActive(true);
        }

    }

}
