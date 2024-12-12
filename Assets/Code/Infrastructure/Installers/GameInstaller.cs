using Code.Gameplay.Features.Level.Behaviours;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private LevelBehaviour _levelBehaviour;
        
        public override void InstallBindings()
        {
            BindLevel();
        }

        private void BindLevel()
        {
            Container.BindInterfacesTo<LevelBehaviour>().FromInstance(_levelBehaviour).AsSingle();
        }
    }
}