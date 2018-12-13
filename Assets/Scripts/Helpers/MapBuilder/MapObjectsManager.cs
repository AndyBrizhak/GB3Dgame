using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Helpers
{
    public class MapObjectsManager : MonoBehaviour
    {

        private const int _platformSize = 7;

        [SerializeField] private GameObject _platform;
        [SerializeField] private List<String> _names;
        [SerializeField] private List<GameObject> _objects;

        public GameObject GetObjectOfType(String type)
        {
            int index = _names.IndexOf(type);
            return _objects[index];
        }

        public GameObject GetDefaultPlatform()
        {
            return _platform;
        }

        public float GetPlatformSize()
        {
            return _platformSize;
        }
    }
}
