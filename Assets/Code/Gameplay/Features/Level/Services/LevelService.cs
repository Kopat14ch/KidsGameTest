using Code.Gameplay.Features.Level.Configs;
using Code.Gameplay.StaticData;

namespace Code.Gameplay.Features.Level.Services
{
    public class LevelService : ILevelService
    {
        private readonly LevelConfig[] _configs;
        
        private int _currentLevel = 0;
        
        public LevelService(IStaticDataService staticDataService)
        {
            _configs = staticDataService.GetLevelConfigs();
        }

        public LevelConfig NextLevel()
        {
            _currentLevel = ++_currentLevel % _configs.Length;

            return GetCurrentConfig();
        }
        
        public LevelConfig GetCurrentConfig() => 
            _configs[_currentLevel];
    }
}