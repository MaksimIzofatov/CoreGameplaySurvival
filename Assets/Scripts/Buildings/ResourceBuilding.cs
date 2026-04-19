using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using Game;
using Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace Buildings
{
    public class ResourceBuilding : Building
    {
        public event Action ProductionResource;
        
        private TypeResource _typeResource;
        private double _currentSpeedProduction;
        private double _currentCapacityResource;
        private double _maxCapacityResource;
        private float _secondToProduction;
        
        private Building _headBuilding;
        private Progress _progresses;
        private WaitForSeconds _waitForSecondToProduction;
        
        public double CurrentCapacityResource => _currentCapacityResource;
        public double MaxCapacityResource => _maxCapacityResource;

        public ResourceBuilding(ResourceManager manager, ILevelFactory factory) : base(manager, factory)
        {
        }

        public override void LevelToUp()
        {
            if (CurrentLevel.CurrentLevel <= _headBuilding.CurrentLevel.CurrentLevel)
            {
                base.LevelToUp();
            }
        }

        public void Initialization(Building headBuilding, Progress progresses, BuildConfig config)
        {
            _headBuilding = headBuilding;
            _progresses = progresses;
            
            _typeResource = config.TypeResource;
            _secondToProduction = config.SecondToProduction;
            _maxCapacityResource = config.MaxCapacityResource;
            _currentSpeedProduction = config.CurrentSpeedProduction;
            _waitForSecondToProduction = new WaitForSeconds(_secondToProduction);
        }

        public void CollectResources()
        {
            _resourceManager.AddResource(_typeResource, _currentCapacityResource);
            _currentCapacityResource = 0;
        }

        public IEnumerator Production()
        {
            while (true)
            {
                yield return _waitForSecondToProduction;
                
                AddResource();
            }
        }

        private void AddResource()
        {
            if(_currentCapacityResource >= _maxCapacityResource) return;
            
            _currentCapacityResource += _currentSpeedProduction;
            ProductionResource?.Invoke();
        }
    }
}