using _Project.Scripts.CubeTowerGameScene.Input;
using _Project.Scripts.CubeTowerGameScene.Services.Balance.Models;
using _Project.Scripts.CubeTowerGameScene.Services.CubeTower;
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
        
        void OnDrop();
        void OnDrop(ICubeDeleteHoleWidget cubeDeleteHoleWidget);
        void OnDrop(ICubeTowerBuildAreaWidget cubeTowerBuildAreaWidget, PointerEventData pointerEventData);
        void OnDrop(CubeTowerCubeWidget cubeTowerCubeWidget);
    }

    public class GameDragAndDropController : IGameDragAndDropController
    {
        public event Action<ICubeBalanceModel> DragStartEvent;
        public event Action DragEndEvent;

        [Inject] private IInputController _inputController;
        [Inject] private ICubeTowerService _cubeTowerService;

        private bool _dropInProcess;

        private ICubeBalanceModel _cubeBalanceModel;
        private CubeTowerCubeWidget _cubeTowerCubeWidget;

        public void OnDrag(ICubeBalanceModel cubeBalanceModel)
        {
            _cubeBalanceModel = cubeBalanceModel;
            _cubeTowerCubeWidget = null;
            _inputController.PointerUpEvent += OnPointerUpEvent;
            DragStartEvent?.Invoke(_cubeBalanceModel);
        }

        public void OnDrag(CubeTowerCubeWidget cubeTowerCubeWidget)
        {
            _cubeBalanceModel = null;
            _cubeTowerCubeWidget = cubeTowerCubeWidget;
            _inputController.PointerUpEvent += OnPointerUpEvent;
            DragStartEvent?.Invoke(_cubeTowerCubeWidget.BalanceModel);
        }

        private void OnPointerUpEvent(Vector2 vector)
        {
            if (_dropInProcess)
                return;

            LogUtils.Error(this, $"OnDrop OnPointerUpEvent");

            OnDrop();
            _inputController.PointerUpEvent -= OnPointerUpEvent;
        }

        public void OnDrop()
        {
            if (!HasDraggableObject())
            {
                _inputController.PointerUpEvent -= OnPointerUpEvent;
                return;
            }

            _dropInProcess = true;
            
            DragEndEvent?.Invoke();

            _cubeBalanceModel = null;
            _cubeTowerCubeWidget = null;

            _dropInProcess = false;
        }

        public void OnDrop(ICubeDeleteHoleWidget cubeDeleteHoleWidget)
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
            }
            else if (_cubeTowerCubeWidget != null)
            {
                var tryResult = _cubeTowerService.TryGetCubeTowerByCubeWidget(_cubeTowerCubeWidget, out var cubeTowerWidget);

                if (tryResult)
                    _cubeTowerService.RemoveCube(cubeTowerWidget, _cubeTowerCubeWidget);
            }

            DragEndEvent?.Invoke();
            _inputController.PointerUpEvent -= OnPointerUpEvent;

            _cubeBalanceModel = null;
            _cubeTowerCubeWidget = null;

            _dropInProcess = false;
        }

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

            DragEndEvent?.Invoke();
            _inputController.PointerUpEvent -= OnPointerUpEvent;

            _cubeBalanceModel = null;
            _cubeTowerCubeWidget = null;

            _dropInProcess = false;
        }

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

        private bool HasDraggableObject()
        {
            var cubeBalanceModelExist = _cubeBalanceModel != null;
            var cubeTowerCubeWidgetExist = _cubeTowerCubeWidget != null;
            var result = cubeBalanceModelExist || cubeTowerCubeWidgetExist;
            return result;
        }
    }
}