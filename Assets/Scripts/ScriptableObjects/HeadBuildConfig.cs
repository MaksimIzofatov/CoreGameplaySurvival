using Game;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Build/Head", menuName = "HeadBuild", order = 0)]
    public class HeadBuildConfig : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private HeadBuilding  _prefab;
        
        public string Name => _name;
        public HeadBuilding Prefab => _prefab;
    }
}