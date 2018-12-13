using System;
using UnityEngine;

using Assets.Scripts.Models;
using UnityEngine.AI;

namespace Assets.Scripts.Helpers
{
    public class MapBuilder
    {
        private System.Random r;
        private MapObjectsManager _objectsManager;
        private GameObject _platform;
        private Transform _mapRoot;
        private int _height;
        private int _width;
        private Platform[][] _map;

        const String road = "DefaultRoad";
        const String border = "RoadBorder";
        const String building = "DefaultBuilding";



        public MapBuilder(MapObjectsManager ObjectManager, int width, int height)
        {
            r = new System.Random();
            _objectsManager = ObjectManager;
            _platform = _objectsManager.GetDefaultPlatform();
            _mapRoot = _objectsManager.transform.parent;
            _width = width;
            _height = height;
            _map = new Platform[width][];
            for (int i = 0; i < width; i++)
                _map[i] = new Platform[height];
        }

        public void Generate()
        {
            float _platformSize = _objectsManager.GetPlatformSize();
            float xOffset = (_objectsManager.GetPlatformSize() * _width) / 2.0f;
            float yOffset = (_objectsManager.GetPlatformSize() * _height) / 2.0f;
            for (int i = 0; i < _width; ++i)
            {
                for(int j = 0; j < _height; ++j)
                {
                    _map[i][j] = GameObject.Instantiate(_platform, new Vector3(-1.0f * xOffset + i * _platformSize, 0, -1.0f * yOffset + j * _platformSize), Quaternion.Euler(0,0,0), _mapRoot).GetComponent<Platform>();
                }
            }

            int roadY = r.Next(6, _height - 6);
            int roadX = r.Next(6, _width - 6);

            for (int i = 0; i < _width; ++i)
            {
                _map[roadY][i].SetType(road, _objectsManager.GetObjectOfType(road));
                _map[roadY + 1][i].SetType(road, _objectsManager.GetObjectOfType(road));
                _map[roadY - 1][i].SetType(border, _objectsManager.GetObjectOfType(border));
                _map[roadY + 2][i].SetType(border, _objectsManager.GetObjectOfType(border));
            }

            for (int i = 0; i < _height; ++i)
            {
                _map[i][roadX].SetType(road, _objectsManager.GetObjectOfType(road));
                _map[i][roadX + 1].SetType(road, _objectsManager.GetObjectOfType(road));
                if (_map[i][roadX - 1].Type() != road)
                    _map[i][roadX - 1].SetType(border, _objectsManager.GetObjectOfType(border));
                if (_map[i][roadX + 2].Type() != road)
                    _map[i][roadX + 2].SetType(border, _objectsManager.GetObjectOfType(border));
            }

            int auxRoadX;
            int auxRoadY;

            if (roadY > _height / 2)
            {
                if (roadX > _width / 2)
                {
                    // up left
                    auxRoadX = r.Next(2, roadX - 5);
                    auxRoadY = r.Next(2, roadY - 5);

                    for (int i = 0; i < _height; ++i)
                    {
                        if (_map[i][auxRoadX].Type() != road)
                        {
                            _map[i][auxRoadX].SetType(border, _objectsManager.GetObjectOfType(border));
                            _map[i][auxRoadX - 1].SetType(border, _objectsManager.GetObjectOfType(border));
                        }
                        else
                        {
                            continue;
                        }
                    }

                    for (int i = 0; i < _width; ++i)
                    {
                        if (_map[auxRoadY][i].Type() != road)
                        {
                            _map[auxRoadY][i].SetType(border, _objectsManager.GetObjectOfType(border));
                            _map[auxRoadY - 1][i].SetType(border, _objectsManager.GetObjectOfType(border));
                        }
                        else
                        {
                            continue;
                        }
                    }

                }
                else
                {
                    // up right
                    auxRoadX = r.Next(roadX + 6, _width);
                    auxRoadY = r.Next(2, roadY - 5);

                    for (int i = 0; i < _height; ++i)
                    {
                        if (_map[i][auxRoadX].Type() != road)
                        {
                            _map[i][auxRoadX].SetType(border, _objectsManager.GetObjectOfType(border));
                            _map[i][auxRoadX - 1].SetType(border, _objectsManager.GetObjectOfType(border));
                        }
                        else
                        {
                            continue;
                        }
                    }

                    for (int i = 0; i < _width; ++i)
                    //for (int i = roadX + 2; i < _width; ++i)
                    {
                        if (_map[auxRoadY][i].Type() != road)
                        {
                            _map[auxRoadY][i].SetType(border, _objectsManager.GetObjectOfType(border));
                            _map[auxRoadY - 1][i].SetType(border, _objectsManager.GetObjectOfType(border));
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            else
            {
                if (roadX > _width / 2)
                {
                    // down left
                    auxRoadX = r.Next(2, roadX - 5);
                    auxRoadY = r.Next(roadY + 6, _height);

                    for (int i = 0; i < _height; ++i)
                    //for (int i = roadY + 3; i < _height; ++i)
                    {
                        if (_map[i][auxRoadX].Type() != road)
                        {
                            _map[i][auxRoadX].SetType(border, _objectsManager.GetObjectOfType(border));
                            _map[i][auxRoadX - 1].SetType(border, _objectsManager.GetObjectOfType(border));
                        }
                        else
                        {
                            continue;
                        }
                    }

                    for (int i = 0; i < _width; ++i)
                    {
                        if (_map[auxRoadY][i].Type() != road)
                        {
                            _map[auxRoadY][i].SetType(border, _objectsManager.GetObjectOfType(border));
                            _map[auxRoadY - 1][i].SetType(border, _objectsManager.GetObjectOfType(border));
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    // down right
                    auxRoadX = r.Next(roadX + 6, _width);
                    auxRoadY = r.Next(roadY + 6, _height);

                    for (int i = 0; i < _height; ++i)
                    //for (int i = roadY + 3; i < _height; ++i)
                    {
                        if (_map[i][auxRoadX].Type() != road)
                        {
                            _map[i][auxRoadX].SetType(border, _objectsManager.GetObjectOfType(border));
                            _map[i][auxRoadX - 1].SetType(border, _objectsManager.GetObjectOfType(border));
                        }
                        else
                        {
                            continue;
                        }
                    }

                    for (int i = 0; i < _width; ++i)
                    //for (int i = roadX + 3; i < _width; ++i)
                    {
                        if (_map[auxRoadY][i].Type() != road)
                        {
                            _map[auxRoadY][i].SetType(border, _objectsManager.GetObjectOfType(border));
                            _map[auxRoadY - 1][i].SetType(border, _objectsManager.GetObjectOfType(border));
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            for (int i = 0; i < _width; ++i)
            {
                for (int j = 0; j < _height; ++j)
                {
                    if (_map[i][j].Type() == "")
                        _map[i][j].SetType(building, _objectsManager.GetObjectOfType(building));
                }
            }
        }
    }
}
