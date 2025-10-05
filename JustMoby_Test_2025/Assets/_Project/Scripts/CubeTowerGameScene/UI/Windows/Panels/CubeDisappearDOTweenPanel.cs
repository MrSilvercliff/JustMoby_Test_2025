using _Project.Scripts.CubeTowerGameScene.Services.ObjectPools;
using _Project.Scripts.CubeTowerGameScene.Services.VFX;
using _Project.Scripts.CubeTowerGameScene.UI.Cubes;
using _Project.Scripts.Project.Camera;
using _Project.Scripts.Project.Extensions;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.CubeTowerGameScene.UI.Windows.Panels
{
    public class CubeDisappearDOTweenPanel : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private float _cubeScaleUpValue;
        [SerializeField] private float _cubeScaleUpDuration;
        [SerializeField] private float _cubeScaleZeroDuration;

        [Inject] private ICameraController _cameraController;
        [Inject] private ICubeTowerGameSceneObjectPoolService _objectPoolService;

        public bool PlaySequence(IDOTweenSequenceData sequenceData)
        {
            var data = (CubeDisappearDOTweenSequenceData)sequenceData;
            var cubeBalanceModel = data.CubeBalanceModel;
            var pointerScreenPosition = data.EventDataPointerPosition;
            var pointerWorldPosition = _cameraController.Camera.ScreenToWorldPoint(pointerScreenPosition);

            var pool = _objectPoolService.CubeWidgetPool;
            var cubeWidget = pool.Spawn();
            cubeWidget.Setup(cubeBalanceModel);
            cubeWidget.transform.SetParent(_container);
            cubeWidget.transform.ResetLocalRotation();
            cubeWidget.transform.ResetLocalScale();
            cubeWidget.transform.position = pointerWorldPosition;
            cubeWidget.transform.ResetLocalZ();
            cubeWidget.SetActive(true);

            var sequence = DOTween.Sequence();
            sequence.OnStart(() => { OnSequenceStart(sequenceData); });
            sequence.Append(cubeWidget.transform.DOScale(_cubeScaleUpValue, _cubeScaleUpDuration));
            sequence.Append(cubeWidget.transform.DOScale(0f, _cubeScaleZeroDuration));
            sequence.OnComplete(() => { OnSequenceComplete(cubeWidget, sequenceData); });
            sequence.Play();

            return true;
        }

        private void OnSequenceStart(IDOTweenSequenceData sequenceData)
        { 
        }

        private void OnSequenceComplete(CubeWidget cubeWidget, IDOTweenSequenceData sequenceData) 
        { 
            var pool = _objectPoolService.CubeWidgetPool;
            pool.Despawn(cubeWidget);
        }
    }
}