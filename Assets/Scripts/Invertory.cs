using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts
{
    public sealed class Invertory
    {
        private List<Item> _items;

        public Invertory()
        {
            _items = new List<Item>();
        }

        public void Add(Item item)
        {
            item.SetActive(false);
            item.DisableRigidBody();
            item.transform.parent = Main.Instance.Hand;
            item.transform.localPosition = Vector3.zero;
            item.transform.localRotation = Quaternion.Euler(Vector3.zero);

            if (item is AutoGunClip)
            {
                AutoGun a = Find<AutoGun>();
                a?.AddClip(item as AutoGunClip);
                return;
            }

            if (item is ShotGunClip)
            {
                ShotGun a = Find<ShotGun>();
                a?.AddClip(item as ShotGunClip);
                return;
            }

            _items.Add(item);
        }

        public Item GetItemByIndex(int index)
        {
            if (index >= _items.Count() || index < 0)
                return null;
            return _items[index];
        }

        public void RemoveItemByIndex(int index)
        {
            if (index >= _items.Count() || index < 0)
                return;
            _items[index].IsVisible = false;
            _items.RemoveAt(index);
        }

        public bool IsEmpty()
        {
            return _items.Count() == 0;
        }

        public int Count()
        {
            return _items.Count();
        }

        public void Print()
        {
            int i = 0;
            foreach (Item item in _items)
            {
                i++;
                Debug.Log(String.Format("{0}: {1}", i, item.name));
            }
        }

        public T Find<T>() where T : Item
        {
            foreach(Item item in _items)
            {
                if (item is T)
                {
                    return item as T;
                }
            }
            return null;
        }

        public Item Take<T>() where T : Item
        {
            foreach (Item item in _items)
            {
                if (item is T)
                {
                    Item tmp = item;
                    _items.Remove(item);
                    return tmp;
                }
            }
            return null;
        }
    }
}
