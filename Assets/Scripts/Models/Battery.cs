using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public sealed class Battery : Item
    {
        [SerializeField] private float _chargeMax = 20.0f;

        public float ChargeMax
        {
            get
            {
                return _chargeMax;
            }
            set
            {
                _chargeMax = value;
                ChargeCurrent = _chargeMax;
                ChargePercent = 1.0f;
            }

        }
        public float ChargeCurrent { get; private set; }
        public float ChargePercent { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            IsVisible = true;
            IsOnceUsable = true;
            ChargeCurrent = _chargeMax;
            ChargePercent = 1.0f;
        }

        public override void MainAction()
        {
            Main.Instance.FlashlightController.Recharge(this);
        }

        public void Use(bool active)
        {
            ChargePercent = ChargeCurrent / ChargeMax;
            if (ChargeCurrent > 0)
            {
                if (active)
                    ChargeCurrent -= Time.deltaTime;
                else
                {
                    if (ChargeCurrent < ChargeMax)
                        ChargeCurrent += Time.deltaTime / 2.0f;
                    else
                        ChargeCurrent = ChargeMax;
                }
            }
            else
                Destroy(_instance);
        }
    }
}
