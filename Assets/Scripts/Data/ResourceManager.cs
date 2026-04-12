using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class ResourceManager
    {
        public event Action<Resource, double> ResourceChanged; 
        private List<Resource> _globalResources;
        
        public IEnumerable<Resource> GlobalResources => _globalResources;

        public ResourceManager()
        {
            _globalResources = new List<Resource>();
        }

        public double GetCountResource(TypeResource typeResource)
        {
            return _globalResources.First(r => r.TypeResource == typeResource).Count;
        }

        public void AddResource(TypeResource typeResource, double currentResource)
        {
            var resource = new Resource(currentResource, typeResource);
            double allCount = currentResource;
            var res = _globalResources.FirstOrDefault(r => r.TypeResource == typeResource);
            if (res == null)
            {
                _globalResources.Add(resource);
            }
            else
            {
                allCount = res.AddCountResource(currentResource);
            }
            
            
            
            ResourceChanged?.Invoke(resource, allCount);
        }

        public void RemoveResource(IList<Resource> currentLevelResources)
        {
            foreach (Resource resource in currentLevelResources)
            {
                var allCount = _globalResources.First(r => r.TypeResource == resource.TypeResource).RemoveCountResource(resource.Count);
                ResourceChanged?.Invoke(resource, allCount);
            }
        }
    }
}