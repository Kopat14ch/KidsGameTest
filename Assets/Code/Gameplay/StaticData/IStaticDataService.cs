using System.Collections.Generic;
using Code.Gameplay.Features.Grid.Config;
using Code.Gameplay.Features.Level.Configs;

namespace Code.Gameplay.StaticData
{
    public interface IStaticDataService
    {
        void LoadAll();

        List<GridElementConfig> GetGridElementConfigs();

        LevelConfig[] GetLevelConfigs();
    }
}