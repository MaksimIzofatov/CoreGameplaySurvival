using Abstracts;
using Game;

namespace Factory
{
    public interface IBuildingFactory
    {
        public HeadBuilding HeadBuilding { get; }
        public bool IsLastBuilding { get; }
        public ResourceBuildingAbstract GetResourceBuildingAbstract();
    }
}