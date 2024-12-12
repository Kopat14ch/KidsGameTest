using Code.Gameplay.Features.Level.Configs;

namespace Code.Gameplay.Features.Level.Services
{
    public interface ILevelService
    {
        bool LevelStarted { get; }

        bool CanNextLevel();
        void NextLevel();
        LevelConfig GetCurrentConfig();
        public void Restart();
        void StartLevel();
    }
}