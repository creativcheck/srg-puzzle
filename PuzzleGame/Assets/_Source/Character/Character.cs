using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using Bonus;

namespace CharacterSystem
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    public class Character : MonoBehaviour
    {
        [Header("Numeric values")]
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _jumpForce;
        [Header("Components")]
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterInput _input;
        [SerializeField] private LoseView _loseView;
        [SerializeField] private BonusView _bonusView;
        [SerializeField] private CharacterSounds _sounds;
        [Space(15)]
        [SerializeField] private List<GameObject> _bonusList;


        [Header("Physical Layers")]
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private LayerMask _bonusLayer, _enemyLayer, _finishLayer;

        private CharacterActions _actions;
        private BonusPool _bonusPool;
        private bool _grounded;

        private void Awake()
        {
            _bonusPool = new BonusPool(_bonusList, _bonusView);

            _actions = new CharacterActions(_speed, _rotationSpeed, _jumpForce, _rigidbody, _animator, _sounds, _bonusPool);

            _input.Init(_actions);
        }

        private void FixedUpdate()
        {
            _actions.ChangeJumpState(_grounded);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(LayerService.CheckLayersEquality(collision.gameObject.layer, _groundLayer))
            {
                _grounded = true;
            }
            if (LayerService.CheckLayersEquality(collision.gameObject.layer, _enemyLayer))
            {
                _actions.Lose(_loseView);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (LayerService.CheckLayersEquality(collision.gameObject.layer, _groundLayer))
            {
                _grounded = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (LayerService.CheckLayersEquality(other.gameObject.layer, _bonusLayer))
            {
                _actions.CollectBonus(other.gameObject);
            }
            if (LayerService.CheckLayersEquality(other.gameObject.layer, _finishLayer))
            {
                _actions.CheckWin();
            }
        }

    }

}
