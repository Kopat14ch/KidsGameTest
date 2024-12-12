using UnityEngine;

namespace Code.Gameplay.Features.Grid.Behaviours
{
    public class GridViewBehaviour : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Vector2 _offset;

        private const int MinHeightFactor = 1;

        public void Init(Vector2Int size, float cellGap, float sizeElement)
        {
            int raw = size.x;
            int column = size.y;
            
            _spriteRenderer.size = new Vector2(column * (sizeElement + cellGap), raw * (sizeElement + cellGap)) + _offset;
        }
    }
}