using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Controllers
{
    public abstract class BaseController
    {
        public bool IsActive { get; private set; }

        public virtual void On()
        {
            IsActive = true;
        }

        public virtual void Off()
        {
            IsActive = false;
        }

        public void Switch()
        {
            if (IsActive)
            {
                Off();
            }
            else
            {
                On();
            }
        }

        public abstract void Update();
    }
}
