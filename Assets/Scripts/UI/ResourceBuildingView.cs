using Buildings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class ResourceBuildingView : MonoBehaviour
    {
        [SerializeField] private Button _levelUpButton;
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private Button _productionButton;
        
        private WaitForSeconds _waitForSecondToProduction;
        private TextMeshProUGUI _productionText;

        private ResourceBuilding _building;
        
        public void Initialization(ResourceBuilding building)
        {
            _building = building;
            _levelUpButton.onClick.AddListener(_building.LevelToUp);
            _productionButton.onClick.AddListener(CollectResource);
            _building.LevelUp += OnLevelUp;
            _building.ProductionResource += OnProductionResource;
        }
        
        private void Start()
        {
            _productionText = _productionButton.GetComponentInChildren<TextMeshProUGUI>();
            StartCoroutine(_building.Production());
            OnLevelUp(_building.CurrentLevel.CurrentLevel);
            OnProductionResource();
        }
        
        private void OnEnable()
        {
        }

        private void OnDisable()
        {
            _levelUpButton.onClick.RemoveListener(_building.LevelToUp);
            _productionButton.onClick.RemoveListener(CollectResource);
            _building.LevelUp -= OnLevelUp;
            _building.ProductionResource -= OnProductionResource;
        }

        private void OnProductionResource()
        {
            _productionText.text = $"{_building.CurrentCapacityResource}/{_building.MaxCapacityResource}";
        }

        private void CollectResource()
        {
            _building.CollectResources();
            OnProductionResource();
        }
        
        public void SetPosition(Transform spawnPoint)
        {
            transform.position = spawnPoint.position;
        }

        private void OnLevelUp(int level)
        {
            _levelText.text = "Уровень: " + level.ToString();
        }
    }
}