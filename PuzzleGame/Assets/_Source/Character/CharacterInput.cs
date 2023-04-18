using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CharacterSystem
{
    public class CharacterInput : MonoBehaviour
    {
        private CharacterActions _actions;
        private MainInput _mainInput;

        private Vector3 _inputVector;

        private void Update()
        {
            _inputVector = _mainInput.Player.Move.ReadValue<Vector3>();
            _actions.Move(_inputVector.y);
            _actions.Rotate(_inputVector.x);
        }

        public void Init(CharacterActions actions)
        {
            _actions = actions;

            _mainInput = new MainInput();

            Bind();
        }

        private void Jumping(InputAction.CallbackContext context)
        {
            _actions.Jump();
        }

        private void Bind()
        {
            _mainInput.Player.Enable();

            _mainInput.Player.Jump.performed += Jumping;
        }

        public void Expose()
        {
            _mainInput.Player.Disable();
            _mainInput.Player.Jump.performed -= Jumping;
        }
    }

}
