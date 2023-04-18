using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSystem
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    public class Character : MonoBehaviour
    {
        [Header("Numeric values")]
        [SerializeField] private float _speed, _rotationSpeed, _jumpForce;
        [Header("Components")]
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterInput _input;
        [SerializeField] private LoseView _loseView;
        [Header("Physical Layers")]
        [SerializeField] private LayerMask _groundLayer, _bonusLayer, _enemyLayer, _deathLayer;

        private CharacterActions _actions;
        private bool _grounded;

        private void Awake()
        {

            _actions = new CharacterActions(_speed, _rotationSpeed, _jumpForce, _rigidbody, _animator);

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

    }

}
