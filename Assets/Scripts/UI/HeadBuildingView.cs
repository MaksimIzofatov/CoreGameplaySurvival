using System;
using Buildings;
using Game;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class HeadBuildingView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentLevel;
        
        public Building HeadBuilding {get; private set;}


        public void Initialization(Building head)
        {
            HeadBuilding = head;
            HeadBuilding.LevelUp += OnLevelUp;
            OnLevelUp(HeadBuilding.CurrentLevel.CurrentLevel);
        }

        private void Start()
        {
        }

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
            HeadBuilding.LevelUp -= OnLevelUp;
        }

        public void SetPosition(Transform spawnPoint)
        {
            transform.position = spawnPoint.position;
        }

        private void OnLevelUp(int level)
        {
            _currentLevel.text = "Уровень: " + level.ToString();
        }
    }
}