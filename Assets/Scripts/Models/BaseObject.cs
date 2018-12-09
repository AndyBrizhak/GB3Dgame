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
        protected bool _isVisible;

        public string Name
        {
            get { return gameObject.name; }
            set
            {
                gameObject.name = value;
            }
        }

        public int Layer {
            get { return _layer; }
            set
            {
                _layer = value;

                AskLayer(_transform, value);
            }
        }

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                var tempRenderer = GetComponent<Renderer>();
                if (tempRenderer)
                    tempRenderer.enabled = _isVisible;
                if (transform.childCount <= 0) return;
                foreach (Transform d in transform)
                {
                    tempRenderer = d.gameObject.GetComponent<Renderer>();
                    if (tempRenderer)
                        tempRenderer.enabled = _isVisible;
                }
            }
        }

        public void DisableRigidBody()
        {
            Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rigidbodies)
            {
                rb.isKinematic = true;
            }
        }
        
        public void EnableRigidBody(float force)
        {
            EnableRigidBody();
            //Rigidbody.isKinematic = false;
            _rigidBody.AddForce(transform.forward * force);
        }
        
        public void EnableRigidBody()
        {
            Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rigidbodies)
            {
                rb.isKinematic = false;
            }
        }

        public void SetActive(bool value)
        {
            IsVisible = value;

            var tempCollider = GetComponent<Collider>();
            if (tempCollider)
            {
                tempCollider.enabled = value;
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

        protected void Invoke(Action method, float time)
        {
            Invoke(method.Method.Name, time);
        }

        protected void CancelInvoke(Action method)
        {
            CancelInvoke(method.Method.Name);
        }

        protected void InvokeRepeating(Action method, float time, float repeatRate)
        {
            InvokeRepeating(method.Method.Name, time, repeatRate);
        }

        protected virtual void OnDisable()
        {
            CancelInvoke();
        }
    }
}
