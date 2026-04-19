using Game;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Build/Head", menuName = "HeadBuild", order = 0)]
    public class HeadBuildConfig : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private HeadBuildingView  _prefab;
        
        public string Name => _name;
        public HeadBuildingView Prefab => _prefab;
    }
}