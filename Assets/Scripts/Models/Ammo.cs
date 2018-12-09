using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Ammo : BaseObject
    {
        protected float _timeToDestruct = 4;
        protected float _baseDamage = 1;

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            Destroy(gameObject, _timeToDestruct);
        }

        public void AddForce(Vector3 dir)
        {
            if (!_rigidBody) return;
            _rigidBody.AddForce(dir);
        }
    }
}
