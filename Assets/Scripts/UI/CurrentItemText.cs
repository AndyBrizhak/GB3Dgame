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
        Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        public void ShowData(String str)
        {
            _text.text = str;
        }
    }
}
