using Game;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MediatorUI : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private BuildingSpawner _spawner;

        private void OnEnable()
        {
            _button.onClick.AddListener(_spawner.SpawnBuilding);
            _spawner.BuildingFinished += OnBuildingFinished;
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(_spawner.SpawnBuilding);
            _spawner.BuildingFinished -= OnBuildingFinished;
        }

        private void OnBuildingFinished()
        {
            _button.interactable = false;
        }    
    }
}