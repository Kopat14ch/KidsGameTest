using System;
using Code.Common;
using Code.Gameplay.Features.Level.Services;
using Zenject;

namespace Code.Gameplay.Features.Level.Behaviours
{
    public class LevelRestartButtonBehaviour : ButtonHandler
    {
        public event Action Clicked;
        
        protected override void OnClicked()
        {
            Clicked?.Invoke();
        }
    }
}