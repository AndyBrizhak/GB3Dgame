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
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(CapsuleCollider))]

    public class Npc : BaseObject, ISetDamage
    {
        public event Action OnPointChange;

        public float Hp = 5;
        private bool _isDead;

        private UnityEngine.AI.NavMeshAgent _agent { get; set; }
        private CharacterController _character { get; set; }
        private CapsuleCollider _capsuleCollider { get; set; }
        public Transform target;     

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            _agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            _character = GetComponent<CharacterController>();
            _capsuleCollider = GetComponent<CapsuleCollider>();

            _agent.updateRotation = false;
            _agent.updatePosition = true;
        }

        public void SetDamage(InfoCollision info)
        {
            if (_isDead) return;
            if (Hp > 0)
            {
                Hp -= info.Damage;
            }

            if (Hp <= 0)
            {
                _isDead = true;
                Color = new Color(0.7f, 0.1f, 0.1f);

                _agent.enabled = false;
                _character.enabled = false;
                _rigidBody.useGravity = true;
                _capsuleCollider.enabled = true;
                _rigidBody.velocity = info.Dir;

                Layer = 11;

                Destroy(gameObject, 5);

                OnPointChange?.Invoke();
            }
        }

        public void Move()
        {
            if (_isDead)
                return;

            if (!_agent)
                return;

            if (target != null)
                _agent.SetDestination(target.position);

            if (_agent.remainingDistance > _agent.stoppingDistance)
            {
                _character.Move(_agent.desiredVelocity);
                
                Vector3 direction = _instance.transform.position - _agent.path.corners.First();

                float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

                _instance.transform.rotation = Quaternion.Euler(0, rotation, 0);
            }
            else
                _character.Move(Vector3.zero);
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
