using System.Collections;
using System.Collections.Generic;
using Code.Gameplay.Features.Grid.Behaviours;
using Code.Gameplay.Features.Level.Services;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Code.Gameplay.Features.Level.Behaviours
{
    [RequireComponent(typeof(LevelViewBehaviour))]
    public class LevelBehaviour : MonoBehaviour, IInitializable
    {
        [SerializeField] private GridBehaviour _gridBehaviour;
        
        private List<GridElementBehaviour> _gridElementBehaviours;
        private GridElementBehaviour _gridElementConfigToFind;
        private LevelViewBehaviour _viewBehaviour;
        
        private ILevelServiceEvent _levelServiceEvent;
        private ILevelService _levelService;

        [Inject]
        public void Construct(ILevelServiceEvent levelServiceEvent, ILevelService levelService)
        {
            _levelService = levelService;
            _levelServiceEvent = levelServiceEvent;
        }
        
        private void Awake()
        {
            _viewBehaviour = GetComponent<LevelViewBehaviour>();
        }

        private void OnEnable()
        {
            _levelServiceEvent.LevelChanged += CreateNew;
            _levelServiceEvent.Restarted += Restart;
        }

        private void OnDisable()
        {
            _levelServiceEvent.LevelChanged -= CreateNew;
            _levelServiceEvent.Restarted -= Restart;

        }

        public IEnumerator Start()
        {
            yield return null;
            
            if (_levelService.LevelStarted == false)
                BounceStart();
        }
        
        public void Initialize()
        {
            CreateNew();
            
            _viewBehaviour.StartFade();
        }

        private void OnGridElementClicked(GridElementBehaviour gridElementBehaviour)
        {
            if (gridElementBehaviour == _gridElementConfigToFind)
            {
                gridElementBehaviour.BounceSuccess();

                _viewBehaviour.OnElementFind();

                foreach (GridElementBehaviour gridElement in _gridElementBehaviours)
                    gridElement.OnClicked -= OnGridElementClicked;
            }
            
            gridElementBehaviour.BounceError();
        }

        private void CreateNew()
        {
            if (_gridElementBehaviours != null)
            {
                foreach (GridElementBehaviour gridElement in _gridElementBehaviours)
                    Destroy(gridElement.gameObject);
                
                _gridElementBehaviours.Clear();
            }
            
            _gridElementBehaviours = _gridBehaviour.CreateGrid();
            
            _gridElementConfigToFind = _gridElementBehaviours[Random.Range(0, _gridElementBehaviours.Count)];

            foreach (GridElementBehaviour gridElementBehaviour in _gridElementBehaviours)
                gridElementBehaviour.OnClicked += OnGridElementClicked;
            
            _viewBehaviour.SetFindText(_gridElementConfigToFind.Config.Name);
        }

        private void BounceStart()
        {
            Debug.Log("Bounce");
            
            foreach (GridElementBehaviour gridElementBehaviour in _gridElementBehaviours)
                gridElementBehaviour.BounceStart();
        }

        private void Restart()
        {
            CreateNew();
        }
    }
}