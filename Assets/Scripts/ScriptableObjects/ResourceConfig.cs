using Data;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Resource/Resource", menuName = "ResourceConfig", order = 0)]
    public class ResourceConfig : ScriptableObject
    {
        [SerializeField] private TypeResource _typeResource;
        [SerializeField] private double _count;
        
        public TypeResource TypeResource => _typeResource;
        public double Count => _count;
    }
}