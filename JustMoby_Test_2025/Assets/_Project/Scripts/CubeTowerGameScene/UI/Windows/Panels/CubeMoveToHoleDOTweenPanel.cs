using _Project.Scripts.CubeTowerGameScene.Services.Balance.Models;
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
    public class CubeMoveToHoleDOTweenPanel : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private float _moveToTopPointDuration;
        [SerializeField] private float _moveToHoleDelay;
        [SerializeField] private float _moveToHoleDuration;

        [Inject] private ICameraController _cameraController;
        [Inject] private ICubeTowerGameSceneObjectPoolService _objectPoolService;

        public bool PlaySequence(IDOTweenSequenceData sequenceData)
        {
            var data = (CubeMoveToHoleDOTweenSequenceData)sequenceData;
            var cubeDeleteHoleTopPoint = data.CubeDeleteHoleWidget.TopPointTransform.position;
            var cubeDeleteHoleHolePoint = data.CubeDeleteHoleWidget.HolePointTransform.position;
            var cubeBalanceModel = data.CubeBalanceModel;
            var startWorldPosition = data.StartWorldPosition;

            var pool = _objectPoolService.CubeWidgetPool;
            var cubeWidget = pool.Spawn();
            cubeWidget.Setup(cubeBalanceModel);
            cubeWidget.transform.SetParent(_container);
            cubeWidget.transform.ResetLocalRotation();
            cubeWidget.transform.ResetLocalScale();
            cubeWidget.transform.position = startWorldPosition;
            cubeWidget.transform.ResetLocalZ();
            cubeWidget.SetActive(true);

            cubeDeleteHoleTopPoint.z = cubeWidget.transform.position.z;
            cubeDeleteHoleHolePoint.z = cubeWidget.transform.position.z;

            var timeAfterDelay = _moveToTopPointDuration + _moveToHoleDelay;

            var sequence = DOTween.Sequence();
            sequence.OnStart(() => { OnSequenceStart(sequenceData); });
            sequence.Append(cubeWidget.transform.DOMove(cubeDeleteHoleTopPoint, _moveToTopPointDuration));
            sequence.Insert(timeAfterDelay, cubeWidget.transform.DOMove(cubeDeleteHoleHolePoint, _moveToHoleDuration));
            sequence.Insert(timeAfterDelay, cubeWidget.transform.DOScale(0f, _moveToHoleDuration));
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