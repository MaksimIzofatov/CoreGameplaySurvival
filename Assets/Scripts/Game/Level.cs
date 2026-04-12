using System.Collections.Generic;
using Data;
using Interfaces;
using Zenject;

namespace Game
{
    public class Level : ILevel
    {
        public int CurrentLevel { get; protected set; }
        public IList<Resource> Resources => _resources;

        private List<Resource> _resources;
        private ResourceManager _resourceManager;

        [Inject]
        public Level(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public void Init(int currentLevel, IList<Resource> resources)
        {
            CurrentLevel = currentLevel;
            _resources = new List<Resource>(resources);
        }
        
        public bool IsUpLevel()
        {
            bool result = true;
            
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