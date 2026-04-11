using Data;
using Factory;
using Zenject;

namespace installers
{
    public class BuildingInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Bind();
        }


        private void Bind()
        {
            Container.Bind<ResourceManager>().AsSingle();
            Container.BindInterfacesTo<BuildingFactory>().AsSingle();
        }
        
        
    }
}