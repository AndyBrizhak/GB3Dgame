using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public sealed class AutoGun : Weapon
    {
        [SerializeField] private float _rechargeTime = 0.1f;
        [SerializeField] private float _force = 2000f;

        public override void MainAction()
        {
            if (!_readyToShoot) return;
            if (_clips.Count() == 0 || _clips.First().AmmoCount == 0) return;

            base.MainAction();

            Ammo am = Instantiate(ammo, _shotPosition.position, _shotPosition.rotation);
            am.AddForce(_shotPosition.transform.forward * _force);
            _readyToShoot = false;

            Invoke(ReadyShoot, _rechargeTime);
        }
    }
}
