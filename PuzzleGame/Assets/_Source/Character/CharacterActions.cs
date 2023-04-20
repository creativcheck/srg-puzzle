using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using Bonus;

namespace CharacterSystem
{
    public class CharacterActions
    {
        private float _speed, _rotationSpeed, _jumpForce;
        private bool _grounded, _dead;

        private BonusPool _bonusPool;
        private Rigidbody _rigidbody;
        private CharacterSounds _sounds;
        private CharacterAnimator _characterAnimator;

        public CharacterActions(float speed, float rotationSpeed, float jumpForce, Rigidbody rigidbody,
            Animator animator, CharacterSounds sounds, BonusPool bonusPool)
        {
            _speed = speed;
            _rotationSpeed = rotationSpeed;
            _jumpForce = jumpForce;

            _sounds = sounds;
            _rigidbody = rigidbody;
            _bonusPool = bonusPool;

            _characterAnimator = new CharacterAnimator(animator);

        }

        public void CollectBonus(GameObject bonus)
        {
            _bonusPool.AddBonus();
            bonus.SetActive(false);
        }

        public void CheckWin()
        {
            if(_bonusPool.CheckWin())
            {

            }
        }

        public void Move(float inputY)
        {
            Vector3 velocity = _rigidbody.transform.forward * inputY * _speed;
            velocity.y = _rigidbody.velocity.y;
            _rigidbody.velocity = velocity;
            _characterAnimator.SetMove(inputY);

            if(_grounded && !_dead && inputY != 0)
            {
                _sounds.PlayWalkSound();
            }
            else
                _sounds.StopWalkSound();
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
                _sounds.PlayJumpSound();
            }
        }

        public void Rotate(float inputX)
        {
            _rigidbody.transform.Rotate(new Vector3(0, inputX * _rotationSpeed * Time.deltaTime, 0), Space.World);
        }

        public void Lose(LoseView loseView)
        {
            _dead = true;
            _sounds.PlayDeathSound();
            loseView.DrawLosePanel();
        }

    }

}
