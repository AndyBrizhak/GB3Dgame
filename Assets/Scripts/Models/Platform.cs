using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Models
{
    public class Platform : BaseObject
    {
        [SerializeField] private String _type;
        [SerializeField] private GameObject _object;
        private Transform _positionToBuild;

        protected override void Awake()
        {
            base.Awake();
            _type = "";
            _positionToBuild = gameObject.transform;
        }

        public void SetType(String type, GameObject obj)
        {
            _type = type;
            _object = obj;
            Instantiate(_object, _positionToBuild);
        }

        public bool HasType()
        {
            return _type != null;
        }

        public string Type()
        {
            return _type;
        }
    }
}
