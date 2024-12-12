using System;
using Code.Common;
using Code.Gameplay.Features.Level.Services;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Level.Behaviours
{
    public class LevelNextButtonBehaviour : ButtonHandler
    {
        private ILevelService _levelService;
        
        public event Action Clicked;

        [Inject]
        public void Construct(ILevelService levelService)
        {
            _levelService = levelService;
        }
        
        protected override void OnClicked()
        {
            Clicked?.Invoke();
            _levelService.NextLevel();
        }
    }
}