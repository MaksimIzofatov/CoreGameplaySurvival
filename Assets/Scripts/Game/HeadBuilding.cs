using System.Collections.Generic;
using Abstracts;

namespace Game
{
    public class HeadBuilding : BuildingAbstract
    {
        private List<ResourceBuildingAbstract>  _resourceBuildings = new List<ResourceBuildingAbstract>();
        // [Inject]
        // protected override void Construct(ResourceManager resourceManager)
        // {
        //     base.Construct(resourceManager);
        // }


        public void AddResourceBuilding(ResourceBuildingAbstract resourceBuilding)
        {
            _resourceBuildings.Add(resourceBuilding);
        }
    }
}