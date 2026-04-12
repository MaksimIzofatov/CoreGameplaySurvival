using Abstracts;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Build/ResourceBuild", menuName = "Build", order = 0)]
    public class BuildConfig : ScriptableObject
    {
        [SerializeField] private int _headBuildingLevel;
        [SerializeField] private ResourceBuildingAbstract _prefab;
        
        public int HeadBuildingLevel => _headBuildingLevel;
        public ResourceBuildingAbstract Prefab => _prefab;
    }
}