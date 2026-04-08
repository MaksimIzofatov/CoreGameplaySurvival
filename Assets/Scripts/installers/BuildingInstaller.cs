using Data;
using Game;
using UnityEngine;
using Zenject;

namespace installers
{
    public class BuildingInstaller : MonoInstaller
    {
        [SerializeField] private HeadBuilding _headBuildingPrefab;
        [SerializeField] private Transform _spawnPoint;
        public override void InstallBindings()
        {
            Bind();
            CreateHeadBuilding();
        }

        private void CreateHeadBuilding()
        {
            HeadBuilding headBuilding = Container.InstantiatePrefabForComponent<HeadBuilding>(_headBuildingPrefab, _spawnPoint.position, Quaternion.identity, null);
            Container.Bind<HeadBuilding>().FromInstance(headBuilding).AsSingle();
        }

        private void Bind()
        {
            Container.Bind<ResourceManager>().AsSingle();
        }
        
        
    }
}