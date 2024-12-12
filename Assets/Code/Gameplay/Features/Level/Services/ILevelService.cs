using Code.Gameplay.Features.Level.Configs;

namespace Code.Gameplay.Features.Level.Services
{
    public interface ILevelService
    {
        LevelConfig NextLevel();
        LevelConfig GetCurrentConfig();
    }
}