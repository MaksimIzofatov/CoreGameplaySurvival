using System;
using System.Collections;
using Abstracts;
using Data;
using UnityEngine;

namespace Game.ResourceBuildings
{
    public class ResourceBuildingMeat : ResourceBuildingAbstract
    {
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

        public void CollectResources()
        {
            _resourceManager.AddResource(_typeResource, _currentCapacityResource);
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
        }
    }
}