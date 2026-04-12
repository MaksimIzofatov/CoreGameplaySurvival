using System.Collections.Generic;
using Data;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Level/Level", menuName = "HeadLevel", order = 0)]
    public class HeadLevelConfig : ScriptableObject
    {
        [SerializeField] private int _level;
        [SerializeField] private List<TypeResource>  _typeResources;
        [SerializeField] private List<double>  _countResources;
        public int Level => _level; 
        public IList<TypeResource> TypeResources => _typeResources;
        public IList<double> CountResources => _countResources;
    }
}