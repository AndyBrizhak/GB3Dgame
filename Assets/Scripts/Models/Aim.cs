using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Aim : BaseObject, ISetDamage
    {
        public event Action OnPointChange;

        public float Hp = 5;
        private bool _isDead;

        public void SetDamage(InfoCollision info)
        {
            if (_isDead) return;
            if (Hp > 0)
            {
                Hp -= info.Damage;
            }

            if (Hp <= 0)
            {
                Color = new Color(0.7f, 0.1f, 0.1f);

                _rigidBody.velocity = info.Dir * 1.5f;
                Destroy(gameObject, 5);

                OnPointChange?.Invoke();
                _isDead = true;
            }
        }
    }
}
