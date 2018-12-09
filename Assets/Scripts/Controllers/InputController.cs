using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public sealed class InputController : BaseController
    {
        private KeyCode _I = KeyCode.I;
        private KeyCode _R = KeyCode.R;
        private KeyCode _F = KeyCode.F;
        private KeyCode _G = KeyCode.G;

        private KeyCode _W = KeyCode.W;
        private KeyCode _A = KeyCode.A;
        private KeyCode _S = KeyCode.S;
        private KeyCode _D = KeyCode.D;

        private int MouseLeftButtonId = 0;
        private int MouseRightButtonId = 1;

        public bool Left { get; private set; }
        public bool Right { get; private set; }
        public bool Up { get; private set; }
        public bool Down { get; private set; }
        public bool ButtonR { get; private set; }
        public bool ButtonG { get; private set; }
        public bool ButtonF { get; private set; }


        public Vector3 MousePosition { get; private set; }
        public bool MouseLeftButton { get; private set; }
        public bool MouseRightButton { get; private set; }
        public bool MouseUpScroll { get; private set; }
        public bool MouseDownScroll { get; private set; }


        public override void Update()
        {
            if (!IsActive)
                return;

            MousePosition = Input.mousePosition;

            if (Input.GetMouseButton(MouseLeftButtonId))
                MouseLeftButton = true;
            else
                MouseLeftButton = false;

            if (Input.GetMouseButton(MouseRightButtonId))
                MouseRightButton = true;
            else
                MouseRightButton = false;

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
                MouseUpScroll = true;
            else
                MouseUpScroll = false;

            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                MouseDownScroll = true;
            else
                MouseDownScroll = false;

            if (Input.GetKeyDown(_R))
                ButtonR = true;
            else
                ButtonR = false;

            if (Input.GetKeyDown(_G))
                ButtonG = true;
            else
                ButtonG = false;

            if (Input.GetKeyDown(_F))
                ButtonF = true;
            else
                ButtonF = false;

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

            if (Input.GetKeyDown(_I))
                Main.Instance.Invertory.Print();
        }
    }
}
