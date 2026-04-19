using System;
using Data;
using Interfaces;
using UnityEngine;
using Zenject;

namespace Buildings
{
    public class Building 
    {
        public event Action<int> LevelUp;
        protected ResourceManager _resourceManager;
        protected ILevelFactory _levelFactory;
        
        public ILevel CurrentLevel { get; private set; }
        
        

        public Building(ResourceManager resourceManager, ILevelFactory levelFactory)
        {
            _resourceManager = resourceManager; 
            _levelFactory = levelFactory;
            UpLevel(CurrentLevel);
        } 


        public virtual void LevelToUp()
        {
            if (CurrentLevel.IsUpLevel())
            {
                UpLevel(CurrentLevel);
            }
        }

        protected void UpLevel(ILevel level)
        {
            if(CurrentLevel != null)
                _resourceManager.RemoveResource(CurrentLevel.Resources);
            
            CurrentLevel = _levelFactory.GetLevel(level);
            LevelUp?.Invoke(CurrentLevel.CurrentLevel);
        }
    }
}

