using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSystem
{
    public class CharacterActions
    {
        private float _speed, _rotationSpeed, _jumpForce;
        private bool _grounded;

        private Rigidbody _rigidbody;
        private CharacterAnimator _characterAnimator;

        public CharacterActions(float speed, float rotationSpeed, float jumpForce, Rigidbody rigidbody, Animator animator)
        {
            _speed = speed;
            _rotationSpeed = rotationSpeed;
            _jumpForce = jumpForce;

            _rigidbody = rigidbody;

            _characterAnimator = new CharacterAnimator(animator);

        }

        public void Move(float inputY)
        {
            Vector3 velocity = _rigidbody.transform.forward * inputY * _speed;
            velocity.y = _rigidbody.velocity.y;
            _rigidbody.velocity = velocity;
            _characterAnimator.SetMove(inputY);

        }

        public void ChangeJumpState(bool isGround)
        {
            _grounded = isGround;

            _characterAnimator.SetGround(_grounded);
        }

        public void Jump()
        {
            if(_grounded)
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

            }
        }

        public void Rotate(float inputX)
        {
            _rigidbody.transform.Rotate(new Vector3(0, inputX * _rotationSpeed * Time.deltaTime, 0), Space.World);
        }

        public void Lose(LoseView loseView)
        {
            loseView.DrawLosePanel();
        }

    }

}
