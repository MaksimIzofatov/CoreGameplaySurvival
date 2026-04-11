using Data;
using UnityEngine;
using Zenject;

namespace Abstracts
{
    public abstract class BuildingAbstract : MonoBehaviour
    {
        protected ResourceManager _resourceManager;
        
        [Inject]
        protected virtual void Construct(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager; 
        }
        
        public void SetPosition(Transform spawnPoint)
        {
            transform.position = spawnPoint.position;
        }
    }
}