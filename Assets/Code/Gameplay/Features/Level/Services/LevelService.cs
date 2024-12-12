using System;
using Code.Gameplay.Features.Level.Configs;
using Code.Gameplay.StaticData;

namespace Code.Gameplay.Features.Level.Services
{
    public class LevelService : ILevelService, ILevelServiceEvent
    {
        private readonly LevelConfig[] _configs;
        
        private int _currentLevel;
        
        public event Action LevelChanged;
        public event Action Restarted;
        
        public bool LevelStarted { get; private set; }
        
        public LevelService(IStaticDataService staticDataService)
        {
            _configs = staticDataService.GetLevelConfigs();
        }

        public void NextLevel()
        { 
            _currentLevel++;

            if (_currentLevel == _configs.Length)
                throw new Exception("Level outside range.");
            
            LevelChanged?.Invoke();
        }

        public void Restart()
        {
            _currentLevel = 0;
            Restarted?.Invoke();
        }
        
        public void StartLevel() => 
            LevelStarted = true;
        
        public LevelConfig GetCurrentConfig() => 
            _configs[_currentLevel];
        
        public bool CanNextLevel() => 
            _currentLevel + 1 < _configs.Length;
    }
}