using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Controllers
{
    public sealed class PlayerController : BaseController
    {
        private IMotor _motor;

        public PlayerController(IMotor motor)
        {
            _motor = motor;
        }

        public override void Update()
        {
            if (!IsActive)
                return;
            _motor.Move();
        }
    }
}
