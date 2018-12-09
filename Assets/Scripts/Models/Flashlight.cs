using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Flashlight : BaseObject
    {
        private Light _light;
        private Battery _battery;

        protected override void Awake()
        {
            base.Awake();

            _light = GetComponent<Light>();
        }

        public void Switch(bool value)
        {
            _light.enabled = value;
        }

        public bool EditBatteryCharge()
        {
            if (!_battery) return false;

            _battery.Use(_light.enabled);
            return true;
        }

        public float BatteryCharge()
        {
            return _battery ? _battery.ChargePercent : 0;
        }

        public void Recharge(Battery battery)
        {
            _battery = battery;
        }
    }
}
