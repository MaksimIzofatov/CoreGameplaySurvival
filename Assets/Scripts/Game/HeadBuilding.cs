using System.Collections.Generic;
using Abstracts;

namespace Game
{
    public class HeadBuilding : BuildingAbstract
    {
        private List<ResourceBuildingAbstract>  _resourceBuildings = new List<ResourceBuildingAbstract>();
        private int _offsetLevel = 2;


        public void AddResourceBuilding(ResourceBuildingAbstract resourceBuilding)
        {
            _resourceBuildings.Add(resourceBuilding);
        }

        public void LevelToUp()
        {
            bool isGoodLevel = true;
            // foreach (ResourceBuildingAbstract resourceBuilding in _resourceBuildings)
            // {
            //     if (resourceBuilding.CurrentLevel.CurrentLevel <= CurrentLevel.CurrentLevel - _offsetLevel)
            //     {
            //         isGoodLevel = false;
            //         break;
            //     }
            // }

            if (CurrentLevel.IsUpLevel() && isGoodLevel)
            {
                UpLevel(CurrentLevel);
            }
        }
    }
}