using System.Collections.Generic;
using Data;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Level/Level", menuName = "HeadLevel", order = 0)]
    public class HeadLevelConfig : ScriptableObject
    {
        [SerializeField] private int _level;
        [SerializeField] private List<ResourceConfig>  _resources;
        public int Level => _level; 
        public IList<ResourceConfig> Resources => _resources;
    }
}