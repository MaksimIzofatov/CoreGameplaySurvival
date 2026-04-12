using System.IO;
using Abstracts;
using Game;
using Interfaces;
using ScriptableObjects;
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
        
        public HeadBuilding HeadBuilding { get; private set; }
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
            
        public ResourceBuildingAbstract GetResourceBuildingAbstract()
        {
            if (_resourceBuildConfigs[_currentResourceBuilding].HeadBuildingLevel >
                HeadBuilding.CurrentLevel.CurrentLevel)
            {
                return null;
            }
            
            var resourceBuilding = _container.InstantiatePrefabForComponent<ResourceBuildingAbstract>(_resourceBuildConfigs[_currentResourceBuilding++].Prefab);
            HeadBuilding.AddResourceBuilding(resourceBuilding);
            resourceBuilding.SetHeadBuilding(HeadBuilding);
            IsLastBuilding = _currentResourceBuilding == _resourceBuildConfigs.Length;
            return resourceBuilding;
        }

        private void CreateHeadBuilding()
        {
             HeadBuilding = _container.InstantiatePrefabForComponent<HeadBuilding>(_headBuildConfig.Prefab);
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