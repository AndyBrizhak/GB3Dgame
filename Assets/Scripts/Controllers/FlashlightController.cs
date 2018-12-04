using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

using Assets.Scripts.Models;
using Assets.Scripts.UI;

namespace Assets.Scripts.Controllers
{
    public class FlashlightController : BaseController
    {
        private Flashlight _flashlight;
        private FlashlightUIImage _ui;

        public FlashlightController()
        {
            _flashlight = MonoBehaviour.FindObjectOfType<Flashlight>();
            _flashlight.Switch(false);
            _ui = MonoBehaviour.FindObjectOfType<FlashlightUIImage>();
        }

        public void Recharge()
        {
            _flashlight.Recharge();
        }

        public override void Update()
        {

            _ui.Percent =  _flashlight.BatteryChargeCurrent / _flashlight.BatteryChargeMax;
            
            if (!_flashlight.EditBatteryCharge())
                Off();
        }

        public override void On()
        {
            if (IsActive) return;
            base.On();
            _flashlight.Switch(true);
            //_flashLightUiText.SetActive(true);
        }

        public override void Off()
        {
            if (!IsActive) return;
            base.Off();
            _flashlight.Switch(false);
            //_flashLightUiText.SetActive(false);
        }
    }
}
