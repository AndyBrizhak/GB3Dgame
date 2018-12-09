using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public struct InfoCollision
    {
        private readonly Vector3 _dir;
        private readonly float _damage;

        public InfoCollision(float damage, Vector3 dir = default(Vector3))
        {
            _damage = damage;
            _dir = dir;
        }

        public Vector3 Dir
        {
            get
            {
                return _dir;
            }
        }

        public float Damage
        {
            get
            {
                return _damage;
            }
        }
    }
}
