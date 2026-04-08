using Abstracts;
using Data;
using Zenject;

namespace Game
{
    public class HeadBuilding : BuildingAbstract
    {
        [Inject]
        protected override void Construct(ResourceManager resourceManager)
        {
            base.Construct(resourceManager);
        }
    }
}