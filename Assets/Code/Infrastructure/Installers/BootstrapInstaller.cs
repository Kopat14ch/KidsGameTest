using Code.Gameplay.Features.Grid.Factory;
using Code.Gameplay.Features.Level.Services;
using Code.Gameplay.StaticData;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Loading;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
    {
        public override void InstallBindings()
        {
            BindInfrastructure();
            BindCommon();
            BindGrid();
            BindLevel();
        }
        
        private void BindInfrastructure()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        }

        private void BindCommon()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
        }

        private void BindGrid()
        {
            Container.Bind<IGridFactory>().To<GridFactory>().AsSingle();
        }

        private void BindLevel()
        {
            Container.BindInterfacesTo<LevelService>().AsSingle();
        }

        public void Initialize()
        {
            Container.Resolve<IStaticDataService>().LoadAll();
            Container.Resolve<ISceneLoader>().LoadScene(Scenes.Game);
        }
    }
}