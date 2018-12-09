using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Assets.Scripts.Models;
using Assets.Scripts.UI;

namespace Assets.Scripts.Controllers
{
    public abstract class BaseController
    {
        protected UiInterface UiInterface;

        protected BaseController()
        {
            UiInterface = new UiInterface();
        }

        public bool IsActive { get; private set; }

        public virtual void On()
        {
            On(null);
        }

        public virtual void On(BaseObject obj = null)
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
