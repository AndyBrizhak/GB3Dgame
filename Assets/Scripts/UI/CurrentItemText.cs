using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public sealed class CurrentItemText : MonoBehaviour
    {
        const float _timeToTranparent = 3.0f;
        const float _timeToBeginTranparent = 1.5f;
        Text _text;
        Color _color;
        float _timeToTransparentLeft;

        private void Awake()
        {
            _text = GetComponent<Text>();
            _color = _text.color;
            _timeToTransparentLeft = _timeToTranparent;
        }

        public void ShowData(String str)
        {
            _text.text = str;
            _timeToTransparentLeft = _timeToTranparent;
            _color.a = 1.0f;
            _text.color = _color;
        }

        private void Update()
        {
            if (_timeToTransparentLeft == 0)
                return;
            
            _timeToTransparentLeft -= Time.deltaTime;
            if (_timeToTransparentLeft <= 0)
            {
                _color.a = 0;
                _timeToTransparentLeft = 0;
            }
            else if (_timeToTransparentLeft <= _timeToBeginTranparent)
            {
                _color.a = _timeToTransparentLeft / _timeToBeginTranparent;
            }
            _text.color = _color;
        }
    }
}
