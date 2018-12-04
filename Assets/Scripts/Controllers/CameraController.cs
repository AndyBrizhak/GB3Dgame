using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public sealed class CameraController : BaseController
    {
        private Transform _camera;
        private Vector3 _cameraPositionShouldBe;
        private Transform _followTo;

        private float _speed = 6.0f;
        private float _yOffset = 25.0f;

        public CameraController(Transform cam)
        {
            _camera = cam;
            _camera.rotation = Quaternion.Euler( new Vector3(90.0f, 0, 0) );
        }

        public void Follow(Transform obj)
        {
            _followTo = obj;
            _cameraPositionShouldBe = _followTo.position;
            _cameraPositionShouldBe.y += _yOffset;
        }

        public override void Update()
        {
            if (!IsActive)
                return;

            _cameraPositionShouldBe = _followTo.position;
            _cameraPositionShouldBe.y += _yOffset;

            _camera.position = Vector3.Slerp(_camera.transform.position, _cameraPositionShouldBe, _speed * Time.deltaTime);
        }
    }
}
