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
        
        void OnDrop();
        void OnDrop(ICubeDeleteHoleWidget cubeDeleteHoleWidget);
        void OnDrop(ICubeTowerBuildAreaWidget cubeTowerBuildAreaWidget, PointerEventData pointerEventData);
    }

    public class GameDragAndDropController : IGameDragAndDropController
    {
        public event Action<ICubeBalanceModel> DragStartEvent;
        public event Action DragEndEvent;

        [Inject] private IInputController _inputController;
        [Inject] private ICubeTowerService _cubeTowerService;

        private bool _dropInProcess;

        private ICubeBalanceModel _cubeBalanceModel;

        public void OnDrag(ICubeBalanceModel cubeBalanceModel)
        {
            _cubeBalanceModel = cubeBalanceModel;
            _inputController.PointerUpEvent += OnPointerUpEvent;
            DragStartEvent?.Invoke(cubeBalanceModel);
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
            _dropInProcess = true;
            DragEndEvent?.Invoke();
            _dropInProcess = false;
        }

        public void OnDrop(ICubeDeleteHoleWidget cubeDeleteHoleWidget)
        {
            LogUtils.Error(this, $"OnDrop Cube Delete Hole Widget 1");

            if (_dropInProcess)
                return;

            LogUtils.Error(this, $"OnDrop Cube Delete Hole Widget 2");

            OnDrop();
            _inputController.PointerUpEvent -= OnPointerUpEvent;
        }

        public void OnDrop(ICubeTowerBuildAreaWidget cubeTowerBuildAreaWidget, PointerEventData pointerEventData)
        {
            LogUtils.Error(this, $"OnDrop Cube Tower Build Area Widget 1");

            if (_dropInProcess)
                return;

            LogUtils.Error(this, $"OnDrop Cube Tower Build Area Widget 2");

            _dropInProcess = true;

            _cubeTowerService.TryBuildTower(cubeTowerBuildAreaWidget.CubeTowerContainer, _cubeBalanceModel);

            DragEndEvent?.Invoke();
            _inputController.PointerUpEvent -= OnPointerUpEvent;

            _dropInProcess = false;
        }
    }
}