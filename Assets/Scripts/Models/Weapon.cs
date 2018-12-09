using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Weapon : Item
    {
        protected bool _readyToShoot = true;

        [SerializeField] protected Transform _shotPosition;
        [SerializeField] protected Ammo ammo;
        protected Queue<Clip> _clips = new Queue<Clip>();


        protected override void Awake()
        {
            base.Awake();
            IsVisible = true;
            IsOnceUsable = false;
        }

        public override void MainAction()
        {
            base.MainAction();

            _clips.First().AmmoCount--;
        }

        public override void AuxAction()
        {
            if (_clips.Count() > 1)
                Reload();
        }

        public void AddClip(Clip clip)
        {
            _clips.Enqueue(clip);
        }

        public void Reload()
        {
            _clips.Dequeue();
        }

        protected void ReadyShoot()
        {
            _readyToShoot = true;
        }

        public override string ShowData()
        {
            if (_clips.Count() == 0)
                return String.Format("{0}/{1}", 0, _clips.Count());
            else
                return String.Format("{0}/{1}", _clips.First().AmmoCount, _clips.Count() - 1);
        }
    }
}
