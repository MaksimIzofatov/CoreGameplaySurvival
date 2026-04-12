using Factory;
using Game;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class MediatorUI : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Button _levelUpButton;
        [SerializeField] private BuildingSpawner _spawner;
        
        private HeadBuilding _headBuilding;

        [Inject]
        private void Construct(IBuildingFactory factory)
        {
            _headBuilding = factory.HeadBuilding;
        }
        
        private void OnEnable()
        {
            _button.onClick.AddListener(SpawnBuilding);
            _levelUpButton.onClick.AddListener(_headBuilding.LevelToUp);
            _spawner.BuildingFinished += OnBuildingFinished;
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(SpawnBuilding);
            _levelUpButton.onClick.RemoveListener(_headBuilding.LevelToUp);
            _spawner.BuildingFinished -= OnBuildingFinished;
        }

        private void OnBuildingFinished()
        {
            _button.interactable = false;
        }

        private void SpawnBuilding()
        {
            if (_spawner.SpawnBuilding() == false)
            {
                Debug.Log("Нужно прокачать главное здание!");
            }
        }
    }
}