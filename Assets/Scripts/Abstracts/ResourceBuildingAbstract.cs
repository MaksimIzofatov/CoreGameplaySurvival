using System;
using System.Collections;
using Data;
using Game;
using UnityEngine;

namespace Abstracts
{
    public class ResourceBuildingAbstract : BuildingAbstract
    {
        public event Action ProductionResource;
        
        private HeadBuilding _headBuilding;
        protected Coroutine _productionCoroutine;
        protected WaitForSeconds _waitForSecondToProduction;
        
        public void LevelToUp()
        {
            if (CurrentLevel.IsUpLevel() && CurrentLevel.CurrentLevel <= _headBuilding.CurrentLevel.CurrentLevel)
            {
                UpLevel(CurrentLevel);
            }
        }
        
        [SerializeField] private TypeResource _typeResource;
        [SerializeField] private double _currentProduction;
        [SerializeField] private double _currentCapacityResource;
        [SerializeField] private double _maxCapacityResource;
        [SerializeField] private float _secondToProduction;

        public double CurrentCapacityResource => _currentCapacityResource;
        public double MaxCapacityResource => _maxCapacityResource;

        private void Start()
        {
            _productionCoroutine = StartCoroutine(Production());
            _waitForSecondToProduction = new WaitForSeconds(_secondToProduction);
        }

        public void SetHeadBuilding(HeadBuilding headBuilding)
        {
            _headBuilding = headBuilding;
        }

        public void CollectResources()
        {
            _resourceManager.AddResource(_typeResource, _currentCapacityResource);
            _currentCapacityResource = 0;
        }

        private IEnumerator Production()
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
            
            _currentCapacityResource += _currentProduction;
            ProductionResource?.Invoke();
        }
    }
}