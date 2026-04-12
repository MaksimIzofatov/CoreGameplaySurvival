using System;
using System.Collections.Generic;
using Factory;
using Interfaces;
using UnityEngine;
using Zenject;

namespace Game
{
    public class BuildingSpawner : MonoBehaviour
    {
        public event Action BuildingFinished;
        
        [SerializeField] private List<Transform> _spawnPoints;
        
        private IBuildingFactory  _buildingFactory;
        private int _currentSpawnPoint;

        [Inject]
        private void Construct(IBuildingFactory factory)
        {
            _buildingFactory = factory;
        }

        private void Awake()
        {
            SpawnHeadBuilding();
        }

        public bool SpawnBuilding()
        {
            var building = _buildingFactory.GetResourceBuildingAbstract();
            if (building == null)
            {
                return false;
            }
            
            building.SetPosition(_spawnPoints[_currentSpawnPoint++]);
            
            if (_buildingFactory.IsLastBuilding)
            {
                BuildingFinished?.Invoke();
            };
            
            return true;
        }

        private void SpawnHeadBuilding()
        {
            _buildingFactory.HeadBuilding.SetPosition(_spawnPoints[_currentSpawnPoint++]);
        }
    }
}