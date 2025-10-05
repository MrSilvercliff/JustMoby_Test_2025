using _Project.Scripts.CubeTowerGameScene.Input;
using _Project.Scripts.CubeTowerGameScene.Services.Balance.Models;
using _Project.Scripts.CubeTowerGameScene.Services.CubeTower;
using _Project.Scripts.CubeTowerGameScene.Services.VFX;
using _Project.Scripts.CubeTowerGameScene.UI.CubeDeleteHole;
using _Project.Scripts.CubeTowerGameScene.UI.CubeTower;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using ZerglingUnityPlugins.Tools.Scripts.Log;

namespace _Project.Scripts.CubeTowerGameScene.UI.Windows.Views
{
    public interface IGameDragAndDropController
    {
        event Action<ICubeBalanceModel> DragStartEvent;
        event Action DragEndEvent;

        void OnDrag(ICubeBalanceModel cubeBalanceModel);
        void OnDrag(CubeTowerCubeWidget cubeTowerCubeWidget);

        void OnDrop(Vector2 pointerEventDataPosition);
        void OnDrop(ICubeDeleteHoleWidget cubeDeleteHoleWidget, Vector3 pointerEventDataWorldPosition);
        void OnDrop(ICubeTowerBuildAreaWidget cubeTowerBuildAreaWidget, PointerEventData pointerEventData);
        void OnDrop(CubeTowerCubeWidget cubeTowerCubeWidget);
    }

    public class GameDragAndDropController : IGameDragAndDropController
    {
        public event Action<ICubeBalanceModel> DragStartEvent;
        public event Action DragEndEvent;

        [Inject] private IInputController _inputController;
        [Inject] private ICubeTowerService _cubeTowerService;
        [Inject] private IDOTweenSequenceService _doTweenSequenceService;

        private bool _dropInProcess;

        private ICubeBalanceModel _cubeBalanceModel;
        private CubeTowerCubeWidget _cubeTowerCubeWidget;

        /// <summary>
        /// Starting drag some cube from scroll
        /// </summary>
        public void OnDrag(ICubeBalanceModel cubeBalanceModel)
        {
            _cubeBalanceModel = cubeBalanceModel;
            _cubeTowerCubeWidget = null;
            _inputController.PointerUpEvent += OnPointerUpEvent;
            DragStartEvent?.Invoke(_cubeBalanceModel);
        }

        /// <summary>
        /// Starting drag some cube from tower
        /// </summary>
        public void OnDrag(CubeTowerCubeWidget cubeTowerCubeWidget)
        {
            _cubeBalanceModel = null;
            _cubeTowerCubeWidget = cubeTowerCubeWidget;
            _inputController.PointerUpEvent += OnPointerUpEvent;
            DragStartEvent?.Invoke(_cubeTowerCubeWidget.BalanceModel);
        }

        /// <summary>
        /// Invoking from input Controller
        /// Look into KeyboardMouseInputController
        /// </summary>
        private void OnPointerUpEvent(Vector2 vector)
        {
            if (_dropInProcess)
                return;

            LogUtils.Error(this, $"OnDrop OnPointerUpEvent");
            OnDrop(vector);
        }

        /// <summary>
        /// Simple drop somewhere on screen
        /// Invokes disappear animation for SCROLL cubes
        /// Does nothing to TOWER cubes - look like it returns to its place
        /// </summary>
        public void OnDrop(Vector2 pointerEventDataPosition)
        {
            _inputController.PointerUpEvent -= OnPointerUpEvent;

            if (!HasDraggableObject())
                return;

            _dropInProcess = true;

            if (_cubeBalanceModel != null)
                _doTweenSequenceService.StartCubeDisappearSequence(_cubeBalanceModel, pointerEventDataPosition);

            DragEndEvent?.Invoke();

            _cubeBalanceModel = null;
            _cubeTowerCubeWidget = null;

            _dropInProcess = false;
        }

        /// <summary>
        /// Drop on cube delete hole
        /// Invokes cube move to hole dotween animation for SCROLL cubes
        /// Invokes cube move to hole dotween animation for TOWER cubes
        /// </summary>
        public void OnDrop(ICubeDeleteHoleWidget cubeDeleteHoleWidget, Vector3 pointerEventDataWorldPosition)
        {
            LogUtils.Error(this, $"OnDrop Cube Delete Hole Widget 1");

            if (!HasDraggableObject())
            {
                _inputController.PointerUpEvent -= OnPointerUpEvent;
                return;
            }

            if (_dropInProcess)
                return;

            LogUtils.Error(this, $"OnDrop Cube Delete Hole Widget 2");

            _dropInProcess = true;

            if (_cubeBalanceModel != null)
            {
                // scroll cube
                _doTweenSequenceService.StartCubeMoveToHoleSequence(cubeDeleteHoleWidget, _cubeBalanceModel, pointerEventDataWorldPosition);
            }
            else if (_cubeTowerCubeWidget != null)
            {
                // tower cube
                var tryResult = _cubeTowerService.TryGetCubeTowerByCubeWidget(_cubeTowerCubeWidget, out var cubeTowerWidget);

                if (tryResult)
                {
                    _doTweenSequenceService.StartCubeMoveToHoleSequence(cubeDeleteHoleWidget, _cubeTowerCubeWidget.BalanceModel, _cubeTowerCubeWidget.transform.position);
                    _cubeTowerService.RemoveCube(cubeTowerWidget, _cubeTowerCubeWidget);
                }
            }

            DragEndEvent?.Invoke();
            _inputController.PointerUpEvent -= OnPointerUpEvent;

            _cubeBalanceModel = null;
            _cubeTowerCubeWidget = null;

            _dropInProcess = false;
        }

        /// <summary>
        /// Drop on tower build area (right part of screen with yellow background)
        /// Invokes tower building in first SCROLL cube dropped
        /// If tower didnt build - invokes SIMPLE DROP
        /// </summary>
        public void OnDrop(ICubeTowerBuildAreaWidget cubeTowerBuildAreaWidget, PointerEventData pointerEventData)
        {
            LogUtils.Error(this, $"OnDrop Cube Tower Build Area Widget 1");

            if (!HasDraggableObject())
            {
                _inputController.PointerUpEvent -= OnPointerUpEvent;
                return;
            }

            if (_dropInProcess)
                return;

            LogUtils.Error(this, $"OnDrop Cube Tower Build Area Widget 2");

            _dropInProcess = true;

            var tryBuildResult = _cubeTowerService.TryBuildTower(cubeTowerBuildAreaWidget.CubeTowerContainer, _cubeBalanceModel);

            if (!tryBuildResult)
            {
                LogUtils.Error(this, $"OnDrop Cube Tower Build Area Widget 3");
                OnDrop(pointerEventData.position);
                return;
            }

            DragEndEvent?.Invoke();
            _inputController.PointerUpEvent -= OnPointerUpEvent;

            _cubeBalanceModel = null;
            _cubeTowerCubeWidget = null;

            _dropInProcess = false;
        }

        /// <summary>
        /// Drop on tower cube
        /// Invokes adding cube if SCROLL cube was dragged
        /// Does nothing if TOWER cube was dragged
        /// </summary>
        public void OnDrop(CubeTowerCubeWidget cubeTowerCubeWidget)
        {
            LogUtils.Error(this, $"OnDrop Cube Tower Cube Widget 1");

            if (!HasDraggableObject())
            {
                _inputController.PointerUpEvent -= OnPointerUpEvent;
                return;
            }

            if (_dropInProcess)
                return;

            _dropInProcess = true;

            LogUtils.Error(this, $"OnDrop Cube Tower Cube Widget 2");

            if (_cubeBalanceModel != null)
            {
                var tryResult = _cubeTowerService.TryGetCubeTowerByCubeWidget(cubeTowerCubeWidget, out var cubeTowerWidget);

                if (tryResult)
                    _cubeTowerService.TryAddCube(cubeTowerWidget, _cubeBalanceModel);
            }

            DragEndEvent?.Invoke();
            _inputController.PointerUpEvent -= OnPointerUpEvent;

            _cubeBalanceModel = null;
            _cubeTowerCubeWidget = null;

            _dropInProcess = false;
        }

        /// <summary>
        /// Simple check for having dragged object
        /// </summary>
        private bool HasDraggableObject()
        {
            var cubeBalanceModelExist = _cubeBalanceModel != null;
            var cubeTowerCubeWidgetExist = _cubeTowerCubeWidget != null;
            var result = cubeBalanceModelExist || cubeTowerCubeWidgetExist;
            return result;
        }
    }
}