using System.Collections.Generic;

namespace Data
{
    public class ResourceManager
    {
        private List<Resource> _globalResources;
        
        public IEnumerable<Resource> GlobalResources => _globalResources;

        public ResourceManager()
        {
            _globalResources = new List<Resource>();
        }

    }
}