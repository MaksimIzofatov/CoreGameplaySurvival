using Data;
using UI;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Build/ResourceBuild", menuName = "Build", order = 0)]
    public class BuildConfig : ScriptableObject
    {
        [SerializeField] private int _headBuildingLevel;
        [SerializeField] private ResourceBuildingView _prefab;
        [SerializeField] private TypeResource _typeResource;
        [SerializeField] private double _currentSpeedProduction;
        [SerializeField] private double _maxCapacityResource;
        [SerializeField] private float _secondToProduction;
        
        public int HeadBuildingLevel => _headBuildingLevel;
        public ResourceBuildingView Prefab => _prefab;
        public TypeResource TypeResource => _typeResource;
        public double CurrentSpeedProduction => _currentSpeedProduction;
        public double MaxCapacityResource => _maxCapacityResource;
        public float SecondToProduction => _secondToProduction;
    }
}