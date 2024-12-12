using Code.Gameplay.Features.Grid.Config;
using UnityEngine;

namespace Code.Gameplay.Features.Grid.Behaviours
{
    [RequireComponent(typeof(GridElementViewBehaviour))]
    public class GridElementBehaviour : MonoBehaviour
    {
        private GridElementViewBehaviour _viewBehaviour;
        
        private void Awake()
        {
            _viewBehaviour = GetComponent<GridElementViewBehaviour>();
        }
        
        public void Init(GridElementConfig config)
        {
            _viewBehaviour.Init(config.Sprite, config.Scale, config.ScaleIcon, config.RotateValue, config.BackgroundColor);
        }
    }
}