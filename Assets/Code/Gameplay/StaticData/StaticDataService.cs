using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Grid.Config;
using Code.Gameplay.Features.Level.Configs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private GridElementConfig[] _gridElementConfigs;
        private LevelConfig[] _levelConfigs;
        
        public void LoadAll()
        {
            LoadGridElementConfigs();
            LoadLevelConfigs();
        }

        public List<GridElementConfig> GetGridElementConfigs()
        {
            if (_gridElementConfigs.Any())
                return _gridElementConfigs.ToList();
            
            throw new Exception("No gridElement configs found");
        }

        public LevelConfig[] GetLevelConfigs()
        {
            if (_levelConfigs.Any())
                return _levelConfigs;
            
            throw new Exception("No level configs found");
        }
            
        
        private void LoadGridElementConfigs() => 
            _gridElementConfigs = Resources.LoadAll<GridElementConfig>("Configs/Grid");
        
        private void LoadLevelConfigs() => 
            _levelConfigs = Resources.LoadAll<LevelConfig>("Configs/Level").OrderBy(l => l.Id).ToArray();
    }
}
