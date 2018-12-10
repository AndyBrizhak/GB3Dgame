﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Models
{
    public class AutoGunAmmo : Ammo
    {
        protected float _baseDamage = 1;

        private void OnCollisionEnter(Collision collision)
        {
            var tempObj = collision.gameObject.GetComponent<ISetDamage>();
            // дописать доп урон
            tempObj?.SetDamage(new InfoCollision(_baseDamage, _rigidBody.velocity));
            Destroy(gameObject);
        }
    }
}
