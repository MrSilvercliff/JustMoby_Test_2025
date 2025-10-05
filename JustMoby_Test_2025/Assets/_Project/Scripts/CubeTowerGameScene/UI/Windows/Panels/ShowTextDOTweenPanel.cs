using _Project.Scripts.CubeTowerGameScene.Services.VFX;
using _Project.Scripts.CubeTowerGameScene.UI.Cubes;
using _Project.Scripts.Project.Extensions;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using ZerglingUnityPlugins.Localization_JSON_Object.Scripts;

namespace _Project.Scripts.CubeTowerGameScene.UI.Windows.Panels
{
    public class ShowTextDOTweenPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _textGameObject;
        [SerializeField] private Transform _textTransform;
        [SerializeField] private CanvasGroup _textCanvasGroup;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private float _scaleUpValue;
        [SerializeField] private float _scaleUpDuration;
        [SerializeField] private float _scaleOneDuration;
        [SerializeField] private float _fadeOutDelay;
        [SerializeField] private float _fadeOutDuration;

        [Inject] private ILocalizationService _localizationService;

        private Sequence _currentSequence;

        private void Awake()
        {
            _currentSequence = null;
        }

        public bool PlaySequence(IDOTweenSequenceData sequenceData)
        {
            var data = (ShowTextDOTweenSequenceData)sequenceData;
            var localeKey = data.TextLocalizationKey;
            var text = _localizationService.Localize(localeKey);

            DOTweenHelper.KillSequence(_currentSequence, false);

            _textTransform.ResetLocalScale();
            _textCanvasGroup.alpha = 1;
            _text.text = text;

            var fadeOutStartTime = _scaleUpDuration + _scaleOneDuration + _fadeOutDelay;

            _currentSequence = DOTween.Sequence();
            _currentSequence.OnStart(() => { OnSequenceStart(sequenceData); });
            _currentSequence.Append(_textTransform.DOScale(_scaleUpValue, _scaleUpDuration));
            _currentSequence.Append(_textTransform.DOScale(1f, _scaleOneDuration));
            _currentSequence.Insert(fadeOutStartTime, _textCanvasGroup.DOFade(0f, _fadeOutDuration));
            _currentSequence.OnComplete(() => { OnSequenceComplete(sequenceData); });
            _currentSequence.Play();

            return true;
        }

        private void OnSequenceStart(IDOTweenSequenceData sequenceData)
        {
        }

        private void OnSequenceComplete(IDOTweenSequenceData sequenceData)
        {
        }
    }
}