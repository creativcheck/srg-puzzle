using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField] private List<Transform> _wayPoints;
        [SerializeField] private float _speed, _stopTime;
        [SerializeField] private bool _loop;
        [SerializeField] private Transform _enemy;

        private int _currentIndex;
        private bool _isGoingForward;
        private bool _moving;

        private void Awake()
        {
            _isGoingForward = true;
            _moving = true;
        }

        private void Update()
        {
            if (_moving)
                PerformedMove();
        }

        private void CheckNextPoint()
        {
            if(_isGoingForward)
            {
                _currentIndex++;

                if(_currentIndex >= _wayPoints.Count)
                {
                    if(_loop)
                    {
                        _currentIndex = 0;
                    }
                    else
                    {
                        _currentIndex = _wayPoints.Count - 2;
                        _isGoingForward = false;
                    }
                }
            }
            else
            {
                _currentIndex--;

                if(_currentIndex < 0)
                {
                    _currentIndex = 1;
                    _isGoingForward = true;
                }
            }
        }

        private void PerformedMove()
        {
            if (_enemy.position != _wayPoints[_currentIndex].position)
                _enemy.position = Vector3.MoveTowards(_enemy.position,
                    _wayPoints[_currentIndex].position,
                    _speed * Time.deltaTime);
            else
                StartCoroutine(StopOnPoint());
        }

        private IEnumerator StopOnPoint()
        {
            _moving = false;
            yield return new WaitForSeconds(_stopTime);

            CheckNextPoint();
            _moving = true;
        }

    }
}

