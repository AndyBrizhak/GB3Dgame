using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public sealed class InputController : BaseController
    {
        private KeyCode _F = KeyCode.F;
        private KeyCode _G = KeyCode.G;

        private KeyCode _W = KeyCode.W;
        private KeyCode _A = KeyCode.A;
        private KeyCode _S = KeyCode.S;
        private KeyCode _D = KeyCode.D;

        public bool Left { get; private set; }
        public bool Right { get; private set; }
        public bool Up { get; private set; }
        public bool Down { get; private set; }

        public override void Update()
        {
            if (!IsActive)
                return;

            if (Input.GetKeyDown(_F))
            {
                Main.Instance.FlashlightController.Switch();
            }

            if (Input.GetKeyDown(_G))
            {
                Main.Instance.FlashlightController.Recharge();
            }

            if (Input.GetKey(_W))
                Up = true;
            else
                Up = false;

            if (Input.GetKey(_A))
                Left = true;
            else
                Left = false;

            if (Input.GetKey(_S))
                Down = true;
            else
                Down = false;

            if (Input.GetKey(_D))
                Right = true;
            else
                Right = false;
        }
    }
}
