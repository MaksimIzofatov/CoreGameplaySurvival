using Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MediatorResourceBuildingUI : MonoBehaviour
    {
        [SerializeField] private Button _levelUpButton;
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private Button _productionButton;
        private TextMeshProUGUI _productionText;

        [SerializeField] private ResourceBuildingAbstract _building;

        private void Start()
        {
            OnLevelUp(_building.CurrentLevel.CurrentLevel);
            _productionText = _productionButton.GetComponentInChildren<TextMeshProUGUI>();
        }
        
        private void OnEnable()
        {
            _levelUpButton.onClick.AddListener(_building.LevelToUp);
            _productionButton.onClick.AddListener(_building.CollectResources);
            _building.LevelUp += OnLevelUp;
            _building.ProductionResource += OnProductionResource;
        }

        private void OnDisable()
        {
            _levelUpButton.onClick.RemoveListener(_building.LevelToUp);
            _productionButton.onClick.RemoveListener(_building.CollectResources);
            _building.LevelUp -= OnLevelUp;
            _building.ProductionResource -= OnProductionResource;
        }

        private void OnProductionResource()
        {
            _productionText.text = $"{_building.CurrentCapacityResource}/{_building.MaxCapacityResource}";
        }

        private void OnLevelUp(int level)
        {
            _levelText.text = "Уровень: " + level.ToString();
        }
    }
}