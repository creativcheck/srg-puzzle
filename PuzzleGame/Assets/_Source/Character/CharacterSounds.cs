using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSystem
{
    public class CharacterSounds : MonoBehaviour
    {
        [SerializeField] private AudioSource _walkSound;
        [SerializeField] private AudioSource _jumpSound;
        [SerializeField] private AudioSource _deathSound;

        public void PlayWalkSound()
        {
            if(!_walkSound.isPlaying)
            {
                _walkSound.Play();
            }
        }

        public void StopWalkSound()
        {
            _walkSound.Stop();
        }

        public void PlayJumpSound()
        {
            _jumpSound.Play();
        }

        public void PlayDeathSound()
        {
            _deathSound.Play();
        }

    }

}
