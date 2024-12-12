using System;
using Code.Gameplay.Features.Grid.Config;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Gameplay.Features.Grid.Behaviours
{
    [RequireComponent(typeof(GridElementViewBehaviour))]
    public class GridElementBehaviour : MonoBehaviour, IPointerDownHandler
    {
        private GridElementViewBehaviour _viewBehaviour;
        public event Action<GridElementBehaviour> OnClicked;
        public GridElementConfig Config { get; private set; }

        private void Awake()
        {
            _viewBehaviour = GetComponent<GridElementViewBehaviour>();
        }
        
        public void Init(GridElementConfig config)
        {
            Config = config;
            _viewBehaviour.Init(config.Sprite, config.Scale, config.ScaleIcon, config.RotateValue, config.BackgroundColor);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnClicked?.Invoke(this);
        }
        
        public void BounceError()
        {
            _viewBehaviour.BounceError();
        }

        public void BounceStart()
        {
            _viewBehaviour.BounceStart();
        }
        
        public void BounceSuccess()
        {
            _viewBehaviour.BounceSuccess();
        }
    }
}