using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public sealed class ShotGun : Weapon
    {
        [SerializeField] private float _rechargeTime = 1f;
        [SerializeField] private float _force = 1500f;
        private int _bulletInShot = 7;

        public override void MainAction()
        {
            if (!_readyToShoot) return;
            if (_clips.Count() == 0 || _clips.First().AmmoCount == 0) return;

            base.MainAction();

            for (int i = 0; i < _bulletInShot; ++i)
            {
                Ammo am = Instantiate(ammo, _shotPosition.position, _shotPosition.rotation);
                float xRandom = UnityEngine.Random.Range(-0.2f, 0.2f);
                float yRandom = UnityEngine.Random.Range(-0.1f, 0.1f);
                float zRandom = UnityEngine.Random.Range(-0.2f, 0.2f);
                Vector3 randomDirection = new Vector3(xRandom, yRandom, zRandom);
                am.AddForce((_shotPosition.transform.forward + randomDirection) * _force);
            }

            _readyToShoot = false;

            Invoke(ReadyShoot, _rechargeTime);
        }
    }
}
