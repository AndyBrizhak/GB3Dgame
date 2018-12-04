using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public abstract class BaseObject : MonoBehaviour
    {
        protected GameObject _instance;
        protected Transform _transform;
        protected Rigidbody _rigidBody;
        protected int _layer;


        public int Layer {
            get { return _layer; }
            set
            {
                _layer = value;

                AskLayer(_transform, value);
            }
        }

        private void AskLayer(Transform obj, int value)
        {
            obj.gameObject.layer = value;

            if (obj.childCount < 0)
                return;

            foreach (Transform child in obj)
            {
                AskLayer(child, value);
            }
        }

        protected virtual void Awake()
        {
            _instance = gameObject;
            _transform = GetComponent<Transform>();
            _rigidBody = GetComponent<Rigidbody>();
        }
    }
}
