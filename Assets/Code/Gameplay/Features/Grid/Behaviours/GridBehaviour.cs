using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Grid.Config;
using Code.Gameplay.Features.Grid.Factory;
using Code.Gameplay.Features.Level.Configs;
using Code.Gameplay.Features.Level.Services;
using Code.Gameplay.StaticData;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Code.Gameplay.Features.Grid.Behaviours
{
    [RequireComponent(typeof(GridViewBehaviour))]
    public class GridBehaviour : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Grid _grid;

        private List<GridElementConfig> _elementConfigs;
        private List<GridElementConfig> _currentLevelElementConfigs;
        private GridViewBehaviour _viewBehaviour;
        private Vector2Int _currentSize;
        private LevelConfig _currentLevelConfig;
        private float _currentCellSize;
        private float _currentCellGap;
        private IGridFactory _factory;
        private ILevelService _levelService;
        private IStaticDataService _staticDataService;

        [Inject]
        public void Construct(IGridFactory factory, ILevelService levelService, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _levelService = levelService;
            _factory = factory;

            _elementConfigs = _staticDataService.GetGridElementConfigs();
        }
        
        private void Awake()
        {
            _viewBehaviour = GetComponent<GridViewBehaviour>();
            _currentLevelElementConfigs = new List<GridElementConfig>();
        }

        public List<GridElementConfig> CreateGrid()
        {
            if (_currentLevelElementConfigs.Any())
                _currentLevelElementConfigs.Clear();
            
            _currentLevelElementConfigs = new List<GridElementConfig>();
            _currentLevelConfig = _levelService.GetCurrentConfig();
            _currentSize = _currentLevelConfig.GridConfig.Size;
            _currentCellSize = _currentLevelConfig.GridConfig.CellSize;
            _currentCellGap = _currentLevelConfig.GridConfig.CellGap;
            
            _grid.cellSize = new Vector3
            {
                x = _currentCellSize, 
                y = _currentCellSize, 
                z = _currentCellSize
            };
            
            _grid.cellGap = new Vector3
            {
                x = _currentCellGap,
                y = _currentCellGap,
                z = _currentCellGap
            };

            Vector3 gridCenter = new Vector3(
                (_currentSize.x - 1) * (_grid.cellSize.x + _currentCellGap) * 0.5f,
                (_currentSize.y - 1) * (_grid.cellSize.y + _currentCellGap) * 0.5f,
                0);
            
            _grid.transform.position = -gridCenter;
            
            for (int i = 0; i < _currentSize.y; i++)
            {
                for (int j = 0; j < _currentSize.x; j++)
                {
                    GridElementConfig elementConfig = GetRandomConfig();
                    
                    _currentLevelElementConfigs.Add(elementConfig);
                    _elementConfigs.Remove(elementConfig);
                    
                    _factory.Create(_grid.transform, _grid.CellToWorld(new Vector3Int(i, j, 0)), elementConfig);
                }
            }
            
            _viewBehaviour.Init(_currentSize, _currentCellGap, _currentCellSize);

            return _currentLevelElementConfigs;
        }

        private GridElementConfig GetRandomConfig()
        {
            if (_elementConfigs.Count == 0)
                throw new InvalidOperationException("No more configs available.");
            
            GridElementConfig elementConfig = _elementConfigs[Random.Range(0, _elementConfigs.Count)];
            
            return elementConfig;
        }
    }
}