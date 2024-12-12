using UnityEngine;

namespace Code.Gameplay.Features.Grid.Behaviours
{
    public class GridElementViewBehaviour : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private SpriteRenderer _backgroundSpriteRenderer;

        private Transform _transform;
        private Transform _spriteRendererTransform;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _spriteRendererTransform = _spriteRenderer.GetComponent<Transform>();
        }

        public void Init(Sprite sprite, Vector3 scale, Vector3 scaleIcon, int rotateValue, Color backgroundColor)
        {
            _spriteRenderer.sprite = sprite;
            _backgroundSpriteRenderer.color = backgroundColor;
            
            ChangeScale(scale, _transform);
            ChangeScale(scaleIcon, _spriteRendererTransform);
            Rotate(rotateValue);
        }

        private void Rotate(int rotateValue)
        {
            if (rotateValue == 0)
                return;
            
            _spriteRendererTransform.Rotate(0, 0, rotateValue);
        }

        private void ChangeScale(Vector3 scale, Transform transformToScale) =>
            transformToScale.localScale = scale;
    }
}