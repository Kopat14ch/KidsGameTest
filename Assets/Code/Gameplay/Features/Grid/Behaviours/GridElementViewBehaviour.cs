using System;
using DG.Tweening;
using UnityEngine;

namespace Code.Gameplay.Features.Grid.Behaviours
{
    public class GridElementViewBehaviour : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private SpriteRenderer _backgroundSpriteRenderer;
        [SerializeField] private ParticleSystem _particleSystem;
        
        private const float BounceOffset = 0.3f;
        private const float BounceStartOffset = 0.4f;
        private const float BounceDuration = 0.3f;

        private Transform _transform;
        private Transform _spriteRendererTransform;
        private Tween _bounceTween;
        private Vector3 _startPosition;

        public void Init(Sprite sprite, Vector3 scale, Vector3 scaleIcon, int rotateValue, Color backgroundColor)
        {
            _transform = GetComponent<Transform>();
            _spriteRendererTransform = _spriteRenderer.transform;
            _startPosition = _spriteRendererTransform.localPosition;
            
            _spriteRenderer.sprite = sprite;
            _backgroundSpriteRenderer.color = backgroundColor;
            
            ChangeScale(scale, _transform);
            ChangeScale(scaleIcon, _spriteRendererTransform);
            Rotate(rotateValue);
        }

        private void OnDestroy()
        {
            _bounceTween.Kill();
        }


        private void Rotate(int rotateValue)
        {
            if (rotateValue == 0)
                return;
            
            _spriteRendererTransform.Rotate(0, 0, rotateValue);
        }
        
        public void BounceError()
        {
            Bounce();
        }
        
        public void BounceSuccess()
        {
            Bounce();
            _particleSystem.Play();
        }

        public void BounceStart()
        {
            Bounce(true);
        }
        
        private void Bounce(bool isStart = false)
        {
            if (_bounceTween != null && _bounceTween.IsActive())
                _bounceTween.Kill();


            if (isStart == false)
            {
                _bounceTween = _spriteRendererTransform.DOLocalMoveX(_startPosition.x + BounceOffset, BounceDuration)
                    .SetEase(Ease.InBounce).
                    OnKill(() =>
                    {
                        _spriteRendererTransform.localPosition = _startPosition;
                    })
                    .OnComplete(() =>
                    {
                        _bounceTween = _spriteRendererTransform.DOLocalMoveX(_startPosition.x, BounceDuration)
                            .SetEase(Ease.InBounce);
                    });
            }
            else
            {
                _bounceTween = _spriteRendererTransform.DOLocalMoveX(_startPosition.x + BounceStartOffset, BounceDuration)
                    .SetEase(Ease.InBounce).
                    OnKill(() =>
                    {
                        _spriteRendererTransform.localPosition = _startPosition;
                    })
                    .OnComplete(() =>
                    {
                        _bounceTween = _spriteRendererTransform.DOLocalMoveX(_startPosition.x, BounceDuration)
                            .SetEase(Ease.InBounce);
                    });
            }
        }

        private void ChangeScale(Vector3 scale, Transform transformToScale) =>
            transformToScale.localScale = scale;
    }
}