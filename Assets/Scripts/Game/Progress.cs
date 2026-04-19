using System.Collections.Generic;
using Buildings;
using Data;
using Interfaces;
using Zenject;

namespace Game
{
    public class Progress : ILevel
    {
        public int CurrentLevel { get; private set; }
        public IList<Resource> Resources { get; private set; }
        private List<Resource> _resources;
        private ResourceManager _resourceManager;
        private ResourceBuilding _building;
        private int _offsetLevel = 2;

        [Inject]
        public Progress(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public void Init(int currentLevel, IList<Resource> resources, ResourceBuilding building)
        {
            CurrentLevel = currentLevel;
            _resources = new List<Resource>(resources);
            _building = building;
        }
        
        public bool IsUpLevel()
        {
            bool result = CurrentLevel >= _building.CurrentLevel.CurrentLevel * _offsetLevel;
            
            foreach (var resource in _resources)
            {
                double count = _resourceManager.GetCountResource(resource.TypeResource);
                if (resource.Count > count)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}