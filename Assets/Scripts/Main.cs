using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Assets.Scripts.Controllers;
using UnityEngine;

namespace Assets.Scripts
{
    public sealed class Main : MonoBehaviour 
    {
        public InputController InputController { get; private set; }
        public PlayerController PlayerController { get; private set; }
        public CameraController CameraController { get; private set; }
        public FlashlightController FlashlightController { get; private set; }

        private List<BaseController> _controllers = new List<BaseController>();
        public static Main Instance { get; private set; }

        private void Awake()
        {
            Instance = this;

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            PlayerController = new PlayerController(new UnitMotor(player.transform));
            PlayerController.On();
            _controllers.Add(PlayerController);

            InputController = new InputController();
            InputController.On();
            _controllers.Add(InputController);

            CameraController = new CameraController(Camera.main.transform);
            CameraController.Follow(player.transform);
            CameraController.On();
            _controllers.Add(CameraController);

            FlashlightController = new FlashlightController();
            FlashlightController.Off();
            _controllers.Add(FlashlightController);
        }

        private void Update()
        {
            foreach(var controller in _controllers)
            {
                controller.Update();
            }
        }
    }
}
