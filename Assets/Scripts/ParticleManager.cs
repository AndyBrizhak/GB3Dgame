using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public sealed class ParticleManager : MonoBehaviour
    {
        public ParticleSystem BulletDestroy;

        public void InstantiateBulletParticle(Vector3 position)
        {
            ParticleSystem ps = Instantiate(BulletDestroy, position, Quaternion.Euler(0, 0, 0));
            ps.Play();
            Destroy(ps.gameObject, ps.main.duration);
        }
    }
}
