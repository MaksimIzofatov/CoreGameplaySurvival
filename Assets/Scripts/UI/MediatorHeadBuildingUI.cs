using System;
using Game;
using TMPro;
using UnityEngine;

namespace UI
{
    public class MediatorHeadBuildingUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentLevel;
        [SerializeField] private HeadBuilding _headBuilding;

        private void Start()
        {
            OnLevelUp(_headBuilding.CurrentLevel.CurrentLevel);
        }

        private void OnEnable()
        {
            _headBuilding.LevelUp += OnLevelUp;
        }

        private void OnDisable()
        {
            _headBuilding.LevelUp -= OnLevelUp;
        }

        private void OnLevelUp(int level)
        {
            _currentLevel.text = "Уровень: " + level.ToString();
        }
    }
}