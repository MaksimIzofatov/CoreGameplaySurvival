using Data;
using UnityEngine;

namespace Abstracts
{
    public abstract class BuildingAbstract : MonoBehaviour
    {
        protected ResourceManager _resourceManager;
        
        protected virtual void Construct(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager; 
        }
    }
}