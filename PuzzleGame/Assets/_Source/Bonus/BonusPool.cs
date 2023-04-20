using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Bonus
{
    public class BonusPool
    {
        private List<GameObject> _bonuses;
        private BonusView _view;

        private int _bonusCount;
        
        public BonusPool(List<GameObject> bonusList, BonusView view)
        {
            _bonuses = bonusList;
            _view = view;
            _view.UpdateBonusView(_bonusCount, _bonuses.Count);
        }

        public void AddBonus()
        {
            _bonusCount++;
            _view.UpdateBonusView(_bonusCount, _bonuses.Count);
        }

        public bool CheckWin()
        {
            if (_bonusCount >= _bonuses.Count)
            {
                _view.OnWin();
                return true;
            }

            return false;
        }
    }

}
