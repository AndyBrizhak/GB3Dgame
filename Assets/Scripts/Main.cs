﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Assets.Scripts.Controllers;
using UnityEngine;

namespace Assets.Scripts
{
    public sealed class Main : MonoBehaviour 
    {
        public GameObject Player { get; private set; }
        public Transform Hand { get; private set; }
        public Camera CameraCurrent { get; private set; }

        public Invertory Invertory { get; private set; }

        public InputController InputController { get; private set; }
        public PlayerController PlayerController { get; private set; }
        public CameraController CameraController { get; private set; }
        public FlashlightController FlashlightController { get; private set; }
        public InHandController InHandController { get; private set; }

        private List<BaseController> _controllers = new List<BaseController>();
        public static Main Instance { get; private set; }

        private void Awake()
        {
            Instance = this;

            Player = GameObject.FindGameObjectWithTag("Player");
            Hand = GameObject.FindGameObjectWithTag("Hand").transform;
            CameraCurrent = Camera.main;
            Invertory = new Invertory();

            CameraController = new CameraController(CameraCurrent.transform);
            CameraController.Follow(Player.transform);
            CameraController.On();
            _controllers.Add(CameraController);

            InputController = new InputController();
            InputController.On();
            _controllers.Add(InputController);

            PlayerController = new PlayerController(new UnitMotor(Player.transform));
            PlayerController.On();
            _controllers.Add(PlayerController);

            InHandController = new InHandController();
            InHandController.On();
            _controllers.Add(InHandController);

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
