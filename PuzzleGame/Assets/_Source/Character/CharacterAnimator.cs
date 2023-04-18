using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSystem
{
    public class CharacterAnimator
    {
        private readonly Animator _animator;

        private readonly int _speedHash = Animator.StringToHash("Speed");
        private readonly int _groundedHash = Animator.StringToHash("Grounded");

        public CharacterAnimator(Animator animator) => _animator = animator;

        public void SetMove(float inputX) => _animator.SetFloat(_speedHash, Mathf.Abs(inputX));

        public void SetGround(bool grounded) => _animator.SetBool(_groundedHash, grounded);

    }

}
