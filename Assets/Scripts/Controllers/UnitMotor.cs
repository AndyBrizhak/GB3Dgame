using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    class UnitMotor : IMotor
    {
        private Transform _instance;

        private Vector3 _moveVector;
        private Vector3 _rotateVector;
        private Quaternion _rotate;
        private float _speedMove = 10;
        private float _speedRotate = 250;
        private float _jumpPower = 12;
        private float _gravityForce;


        Vector3 _input;

        private CharacterController _characterController;

        public UnitMotor(Transform obj)
        {
            _instance = obj;
            _characterController = _instance.GetComponent<CharacterController>();
            _rotate = _instance.localRotation;
        }

        public void Move()
        {
            CharacterGravity();
            CharacterRotate();
            CharacterMove();
        }

        private void CharacterRotate()
        {
            _rotateVector = Vector3.zero;

            if (Main.Instance.InputController.Left)
            {
                _rotateVector.y = -1 * _speedRotate * Time.deltaTime;
            }

            if (Main.Instance.InputController.Right)
            {
                _rotateVector.y = 1 * _speedRotate * Time.deltaTime;
            }

            _rotate *= Quaternion.Euler(_rotateVector);

            //_instance.localRotation = Quaternion.Slerp(_instance.localRotation, _rotate, _speedRotate * Time.deltaTime);
            _instance.localRotation = _rotate;

        }

        private void CharacterMove()
        {
            _input = Vector2.zero;

            if (_characterController.isGrounded)
            {

                if (Main.Instance.InputController.Up)
                {
                    _input.x = 1;
                }

                if (Main.Instance.InputController.Down)
                {
                    _input.x = -1;
                }
                Vector3 desiredMove = _instance.forward * _input.x;

                _moveVector.x = desiredMove.x * _speedMove;
                _moveVector.z = desiredMove.z * _speedMove;
            }
            
            if (_input.Equals(Vector3.zero))
                _moveVector = Vector3.Slerp(Vector3.zero, _moveVector, 60f * Time.deltaTime);
            
            _moveVector.y = _gravityForce;

            _characterController.Move(_moveVector * Time.deltaTime);
        }

        private void CharacterGravity()
        {
            if (!_characterController.isGrounded)
                _gravityForce -= 30 * Time.deltaTime;
            else
                _gravityForce = -1;

            if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
                _gravityForce = _jumpPower;
        }
    }
}
