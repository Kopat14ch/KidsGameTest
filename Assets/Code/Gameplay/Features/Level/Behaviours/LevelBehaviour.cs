using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Grid.Behaviours;
using Code.Gameplay.Features.Grid.Config;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Gameplay.Features.Level.Behaviours
{
    [RequireComponent(typeof(LevelViewBehaviour))]
    public class LevelBehaviour : MonoBehaviour
    {
        [SerializeField] private GridBehaviour _gridBehaviour;
        
        private List<GridElementConfig> _gridElementConfigs;
        private LevelViewBehaviour _viewBehaviour;

        private void Awake()
        {
            _viewBehaviour = GetComponent<LevelViewBehaviour>();
        }

        private void Start()
        {
            _gridElementConfigs = _gridBehaviour.CreateGrid();
            
            _viewBehaviour.StartFade(_gridElementConfigs[Random.Range(0, _gridElementConfigs.Count)].Name);
        }
    }
}