using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Item : BaseObject
    {
        public bool IsOnceUsable { get; protected set; }

        public virtual void MainAction()
        {
        }

        public virtual void AuxAction()
        {
        }

        protected override void Awake()
        {
            base.Awake();
        }

        public virtual String ShowData()
        {
            return "";
        }

        protected void OnTriggerEnter(Collider other)
        {
            if (IsVisible)
            {
                if (other.gameObject.tag == "Player")
                {
                    Main.Instance.Invertory.Add(this);
                }
            }
        }
    }
}
