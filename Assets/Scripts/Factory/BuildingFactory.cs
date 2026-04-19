using System.Collections.Generic;
using System.IO;
using Buildings;
using Game;
using Interfaces;
using ScriptableObjects;
using UI;
using UnityEngine;
using Zenject;

namespace Factory
{
    public class BuildingFactory : IBuildingFactory
    {
        private const string HeadBuildingConfig = nameof(HeadBuildingConfig); 
        private const string BuildingMeatConfig = nameof(BuildingMeatConfig); 
        private const string BuildingWoodConfig = nameof(BuildingWoodConfig); 
        private const string BuildingStoneConfig = nameof(BuildingStoneConfig); 
        
        private const string BuildingConfigs = nameof(BuildingConfigs);
        
        public HeadBuildingView HeadBuilding { get; private set; }
        public bool IsLastBuilding { get; private set; }
        
        private BuildConfig[] _resourceBuildConfigs;

        private HeadBuildConfig _headBuildConfig;

        private IInstantiator _container;
        private int _currentResourceBuilding;

        [Inject]
        public BuildingFactory(IInstantiator container)
        {
            _container = container;
            Load();
            CreateHeadBuilding();
        }
            
        public ResourceBuildingView GetResourceBuildingAbstract()
        {
            if (_resourceBuildConfigs[_currentResourceBuilding].HeadBuildingLevel >
                HeadBuilding.HeadBuilding.CurrentLevel.CurrentLevel)
            {
                return null;
            }

            ResourceBuilding building = _container.Instantiate<ResourceBuilding>();
            // factory!
            Progress progress = _container.Instantiate<Progress>();
            //
            var config = _resourceBuildConfigs[_currentResourceBuilding++];
            building.Initialization(HeadBuilding.HeadBuilding, progress, config);
            var resourceBuilding = _container.InstantiatePrefabForComponent<ResourceBuildingView>(config.Prefab);
            resourceBuilding.Initialization(building);
           
            IsLastBuilding = _currentResourceBuilding == _resourceBuildConfigs.Length;
            return resourceBuilding;
        }

        private void CreateHeadBuilding()
        {
             Building head = _container.Instantiate<Building>();
             HeadBuilding = _container.InstantiatePrefabForComponent<HeadBuildingView>(_headBuildConfig.Prefab);
             HeadBuilding.Initialization(head);
        }

        private void Load()
        {
            _headBuildConfig = Resources.Load<HeadBuildConfig>(Path.Combine(BuildingConfigs, HeadBuildingConfig));
            
            var resourceConfigMeat = Resources.Load<BuildConfig>(Path.Combine(BuildingConfigs, BuildingMeatConfig));
            var resourceConfigWood = Resources.Load<BuildConfig>(Path.Combine(BuildingConfigs, BuildingWoodConfig));
            var resourceConfigStone = Resources.Load<BuildConfig>(Path.Combine(BuildingConfigs, BuildingStoneConfig));
            
            _resourceBuildConfigs = new BuildConfig[] {resourceConfigMeat, resourceConfigWood, resourceConfigStone};
        }
        
    }
}