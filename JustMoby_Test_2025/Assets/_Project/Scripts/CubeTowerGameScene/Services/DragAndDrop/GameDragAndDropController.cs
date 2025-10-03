using _Project.Scripts.CubeTowerGameScene.Input;
using _Project.Scripts.CubeTowerGameScene.Services.Balance.Models;
using _Project.Scripts.CubeTowerGameScene.UI.CubeDeleteHole;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZerglingUnityPlugins.Tools.Scripts.Log;

namespace _Project.Scripts.CubeTowerGameScene.Services.DragAndDrop
{
    public interface IGameDragAndDropController
    {
        event Action<ICubeBalanceModel> DragStartEvent;
        event Action DragEndEvent;

        void OnDrag(ICubeBalanceModel cubeBalanceModel);
        void OnDrop(CubeDeleteHoleWidget cubeDeleteHoleWidget);
    }

    public class GameDragAndDropController : IGameDragAndDropController
    {
        public event Action<ICubeBalanceModel> DragStartEvent;
        public event Action DragEndEvent;

        [Inject] private IInputController _inputController;

        private bool _dropInProcess;

        public void OnDrag(ICubeBalanceModel cubeBalanceModel)
        {
            _inputController.PointerUpEvent += OnPointerUpEvent;
            DragStartEvent?.Invoke(cubeBalanceModel);
        }

        public void OnDrop(CubeDeleteHoleWidget cubeDeleteHoleWidget)
        {
            LogUtils.Error(this, $"OnDrop CubeDeleteHoleWidget 1");

            if (_dropInProcess)
                return;

            LogUtils.Error(this, $"OnDrop CubeDeleteHoleWidget 2");

            OnDrop();
            _inputController.PointerUpEvent -= OnPointerUpEvent;
        }

        private void OnPointerUpEvent(Vector2 vector)
        {
            if (_dropInProcess)
                return;

            LogUtils.Error(this, $"OnDrop OnPointerUpEvent");

            OnDrop();
            _inputController.PointerUpEvent -= OnPointerUpEvent;
        }

        private void OnDrop()
        {
            _dropInProcess = true;
            DragEndEvent?.Invoke();
            _dropInProcess = false;
        }
    }
}