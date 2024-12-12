using System;
using Code.Common.Extensions;
using Code.Gameplay.Features.Level.Services;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Features.Level.Behaviours
{
    public class LevelViewBehaviour : MonoBehaviour
    {
        [SerializeField] private LevelNextButtonBehaviour _nextButton;
        [SerializeField] private LevelRestartButtonBehaviour _restartButton;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Text _levelText;
        [SerializeField] private CanvasGroup _textCanvasGroup;
        [SerializeField] private CanvasGroup _nextCanvasGroup;
        [SerializeField] private CanvasGroup _endCanvasGroup;
        
        private ILevelService _levelService;
        private Tween _endCanvasTween;

        private const float DurationToShowText = 3f;
        private const float DurationToEndCanvas = 2f;

        [Inject]
        public void Construct(ILevelService levelService)
        {
            _levelService = levelService;
        }
        
        private void Awake()
        {
            _textCanvasGroup.Disable();
            _nextCanvasGroup.Disable();
            _endCanvasGroup.Disable();
        }

        private void OnEnable()
        {
            _nextButton.Clicked += OnNextButtonClick;
            _restartButton.Clicked += OnRestartButtonClick;
        }

        private void OnDisable()
        {
            _nextButton.Clicked -= OnNextButtonClick;
            _restartButton.Clicked -= OnRestartButtonClick;
        }

        public void StartFade()
        {
            _textCanvasGroup.DOFade(1, DurationToShowText);
        }

        public void SetFindText(string findName)
        {
            _levelText.text = $"Find {findName}";
        }

        public void OnElementFind()
        {
            if (_levelService.CanNextLevel())
            {
                _nextCanvasGroup.Enable();
            }
            else
            {
                _endCanvasGroup.Enable(false);
                _endCanvasTween = _endCanvasGroup.DOFade(1, DurationToEndCanvas);
            }
        }

        private void OnNextButtonClick()
        { 
            _nextCanvasGroup.Disable();
        }

        private void OnRestartButtonClick()
        {
            _backgroundImage.DOFade(1, DurationToEndCanvas).OnComplete(() =>
            {
                _levelService.Restart();
                _endCanvasGroup.Disable();
            });
        }
    }
}