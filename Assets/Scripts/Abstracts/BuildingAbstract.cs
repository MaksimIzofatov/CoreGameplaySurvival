using System;
using Data;
using Game;
using Interfaces;
using UnityEngine;
using Zenject;

namespace Abstracts
{
    public abstract class BuildingAbstract : MonoBehaviour
    {
        public event Action<int> LevelUp;
        protected ResourceManager _resourceManager;
        protected ILevelFactory _levelFactory;
        
        public ILevel CurrentLevel { get; private set; }
        
        [Inject]
        protected void Construct(ResourceManager resourceManager, ILevelFactory levelFactory)
        {
            _resourceManager = resourceManager; 
            _levelFactory = levelFactory;
        }

        private void Awake()
        {
            UpLevel(CurrentLevel);
        }

        public void SetPosition(Transform spawnPoint)
        {
            transform.position = spawnPoint.position;
        }

        public void UpLevel(ILevel level)
        {
            if(CurrentLevel != null)
                _resourceManager.RemoveResource(CurrentLevel.Resources);
            
            CurrentLevel = _levelFactory.GetLevel(level);
            LevelUp?.Invoke(CurrentLevel.CurrentLevel);
        }
    }
}