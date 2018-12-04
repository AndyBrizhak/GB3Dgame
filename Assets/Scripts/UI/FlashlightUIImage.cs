using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.UI
{
    public class FlashlightUIImage : MonoBehaviour
    {
        private Image _image;
        private float _percent = 1.0f;

        public float Percent {
            get {
                return _percent;
            }
            set
            {
                _percent = value;
                _image.fillAmount = _percent;
            }
        }

        private void Awake()
        {
            _image = GetComponent<Image>();
        }
    }
}
