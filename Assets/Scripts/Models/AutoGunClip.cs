using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models
{
    public sealed class AutoGunClip : Clip
    {
        protected override void Awake()
        {
            base.Awake();
            AmmoCount = 100;
        }
    }
}
