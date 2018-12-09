using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class UiInterface
    {
        private FlashlightUIImage _flashLightUiText;

        public FlashlightUIImage LightUiText
        {
            get
            {
                if (!_flashLightUiText)
                    _flashLightUiText = MonoBehaviour.FindObjectOfType<FlashlightUIImage>();
                return _flashLightUiText;
            }
        }

        private WeaponUiText _weaponUiText;

        public WeaponUiText WeaponUiText
        {
            get
            {
                if (!_weaponUiText)
                    _weaponUiText = MonoBehaviour.FindObjectOfType<WeaponUiText>();
                return _weaponUiText;
            }
        }
        
        private CurrentItemText _currentItemText;

        public CurrentItemText CurrentItemText
        {
            get
            {
                if (!_currentItemText)
                    _currentItemText = MonoBehaviour.FindObjectOfType<CurrentItemText>();
                return _currentItemText;
            }
        }
    }
}
