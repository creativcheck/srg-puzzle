using TMPro;
using UnityEngine;

namespace UI
{
    public class BonusView : MonoBehaviour
    {
        [SerializeField] private WinView _winPanel;
        [SerializeField] private TextMeshProUGUI _bonusText;

        public void UpdateBonusView(int bonuses, int maxBonuses)
        {
            _bonusText.text = $"Bonuses: {bonuses} / {maxBonuses}";
        }

        public void OnWin()
        {
            _winPanel.DrawWinPanel();
        }

    }

}
