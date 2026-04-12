using System;
using Data;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class GlobalResourceUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _meatText;
        [SerializeField] private TextMeshProUGUI _woodText;
        [SerializeField] private TextMeshProUGUI _stoneText;
        
        private ResourceManager _resourceManager;
        
        [Inject]
        private void Construct(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        private void OnEnable()
        {
            _resourceManager.ResourceChanged += OnResourceChanged;
        }

        private void OnDisable()
        {
            _resourceManager.ResourceChanged -= OnResourceChanged;
        }

        private void OnResourceChanged(Resource resource, double allCount)
        {
            switch (resource.TypeResource )
            {
                case TypeResource.Meat: _meatText.text = allCount.ToString(); break;
                case TypeResource.Wood: _woodText.text = allCount.ToString(); break;
                case TypeResource.Stone: _stoneText.text = allCount.ToString(); break;
            }
        }
    }
}