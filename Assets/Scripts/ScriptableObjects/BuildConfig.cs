using Abstracts;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Build/ResourceBuild", menuName = "Build", order = 0)]
    public class BuildConfig : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private ResourceBuildingAbstract _prefab;
        
        public string Name => _name;
        public ResourceBuildingAbstract Prefab => _prefab;
    }
}