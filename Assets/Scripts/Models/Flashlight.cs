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

        public float BatteryChargeMax { get; private set; }
        public float BatteryChargeCurrent { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            _light = GetComponent<Light>();
            BatteryChargeMax = 20.0f;
            BatteryChargeCurrent = BatteryChargeMax;
        }

        public void Switch(bool value)
        {
            _light.enabled = value;
        }

        public bool EditBatteryCharge()
        {
            if (BatteryChargeCurrent > 0)
            {
                if (_light.enabled)
                    BatteryChargeCurrent -= Time.deltaTime;
                else
                {
                    if (BatteryChargeCurrent < BatteryChargeMax)
                        BatteryChargeCurrent += Time.deltaTime / 2.0f;
                    else
                        BatteryChargeCurrent = BatteryChargeMax;
                }
                return true;
            }

            return false;
        }

        public void Recharge()
        {
            BatteryChargeCurrent = BatteryChargeMax;
        }
    }
}
