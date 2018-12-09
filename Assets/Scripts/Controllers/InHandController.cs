using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class InHandController : BaseController
    {
        private Item _item;
        private int _currentItemIndex = -1;

        public override void On(BaseObject obj = null)
        {
            base.On(obj);

            _item = obj as Item;
        }

        public void MainUse()
        {
            _item.MainAction();
            if (_item.IsOnceUsable)
            {
                _item = null;
                Main.Instance.Invertory.RemoveItemByIndex(_currentItemIndex);
            }
            else
                UiInterface.WeaponUiText.ShowData(_item.ShowData());
            UiInterface.CurrentItemText.ShowData(_item ? _item.Name : "");
        }

        public void AuxUse()
        {
            _item.AuxAction();
            UiInterface.WeaponUiText.ShowData(_item.ShowData());
        }

        public void NextItem()
        {
            if (Main.Instance.Invertory.IsEmpty()) return;
            if (_item) _item.IsVisible = false;

            _currentItemIndex++;

            _item = Main.Instance.Invertory.GetItemByIndex(_currentItemIndex);
            if (_item == null)
                _currentItemIndex = 0;
            _item = Main.Instance.Invertory.GetItemByIndex(_currentItemIndex);

            _item.IsVisible = true;
            UiInterface.WeaponUiText.ShowData(_item.ShowData());
            UiInterface.CurrentItemText.ShowData(_item.Name);
        }

        public void PrevItem()
        {
            if (Main.Instance.Invertory.IsEmpty()) return;
            if (_item) _item.IsVisible = false;

            _currentItemIndex--;

            _item = Main.Instance.Invertory.GetItemByIndex(_currentItemIndex);
            if (_item == null)
                _currentItemIndex = Main.Instance.Invertory.Count() - 1;
            _item = Main.Instance.Invertory.GetItemByIndex(_currentItemIndex);

            _item.IsVisible = true;
            UiInterface.WeaponUiText.ShowData(_item.ShowData());
            UiInterface.CurrentItemText.ShowData(_item.Name);
        }

        public override void Update()
        {
            if (!IsActive) return;

            if (Main.Instance.InputController.MouseUpScroll)
            {
                NextItem();
            }

            if (Main.Instance.InputController.MouseDownScroll)
            {
                PrevItem();
            }

            if (!_item) return;

            if (Main.Instance.InputController.MouseLeftButton)
            {
                MainUse();
            }

            if (Main.Instance.InputController.MouseRightButton)
            {
                AuxUse();
            }
        }
    }
}
