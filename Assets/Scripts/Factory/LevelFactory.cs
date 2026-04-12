using System.Collections.Generic;
using System.IO;
using System.Linq;
using Abstracts;
using Data;
using Game;
using Interfaces;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Factory
{
    public class LevelFactory : ILevelFactory
    {
        private const string LevelConfigs = nameof(LevelConfigs);
        private const string HeadLevels = nameof(HeadLevels);
        private List<HeadLevelConfig> _levelHeadConfigs;
        
        private List<Level> _levels = new List<Level>();
        private List<Resource> _tempResources;
        private IInstantiator _container;
        
        [Inject]
        public LevelFactory(IInstantiator container)
        {
            _tempResources = new List<Resource>();
            _container = container;
            
            LoadLevels();
            CreateLevels();
        }

        public ILevel GetLevel(ILevel currentLevel)
        {
            if(currentLevel == null) return _levels[0];
            
            int nextLevelIndex = currentLevel.CurrentLevel;
            return _levels[nextLevelIndex];
        }

        private void CreateLevels()
        {
            foreach (HeadLevelConfig headLevelConfig in _levelHeadConfigs)
            {
                _tempResources.Clear();

                for (int i = 0; i < headLevelConfig.TypeResources.Count; i++)
                {
                    var resource = new Resource(headLevelConfig.CountResources[i], headLevelConfig.TypeResources[i]);
                    _tempResources.Add(resource);
                }

                Level level = _container.Instantiate<Level>();
                level.Init(headLevelConfig.Level, _tempResources);
                _levels.Add(level);
            }
        }

        private void LoadLevels()
        {
            var levels = Resources.LoadAll(Path.Combine(LevelConfigs, HeadLevels)).ToList();
            _levelHeadConfigs = new List<HeadLevelConfig>();
            foreach (Object level in levels)
            {
                _levelHeadConfigs.Add((HeadLevelConfig)level);
            }
        }
    }
}