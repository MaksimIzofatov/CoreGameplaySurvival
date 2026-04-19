using Buildings;
using Game;
using UI;

namespace Interfaces
{
    public interface IBuildingFactory
    {
        public HeadBuildingView HeadBuilding { get; }
        public bool IsLastBuilding { get; }
        public ResourceBuildingView GetResourceBuildingAbstract();
    }
}