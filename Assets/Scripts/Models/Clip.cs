using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models
{
    public class Clip : Item
    {
        public int AmmoCount;

        protected override void Awake()
        {
            base.Awake();
            IsVisible = true;
            IsOnceUsable = true;
        }
    }
}
