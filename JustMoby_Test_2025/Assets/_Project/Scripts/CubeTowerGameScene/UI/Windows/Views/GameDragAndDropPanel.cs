using _Project.Scripts.CubeTowerGameScene.Input;
using _Project.Scripts.CubeTowerGameScene.Services.Balance.Models;
using _Project.Scripts.CubeTowerGameScene.UI.Cubes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZerglingUnityPlugins.Tools.Scripts.Mono;

namespace _Project.Scripts.CubeTowerGameScene.UI.Windows.Views
{
    public class GameDragAndDropPanel : MonoBehaviour, IMonoUpdatable
    {
        [SerializeField] private CubeWidget _draggedWidget;

        [Inject] private IInputController _inputController;
        [Inject] private IGameDragAndDropController _dragAndDropController;
        [Inject] private IMonoUpdater _monoUpdater;

        private bool _isDragging;

        public void Init()
        {
            _isDragging = false;
        }

        public void Activate()
        {
            _dragAndDropController.DragStartEvent += OnDragStartEvent;
            _dragAndDropController.DragEndEvent += OnDragEndEvent;
            _monoUpdater.Subscribe(this);
        }

        public void Deactivate()
        {
            _dragAndDropController.DragStartEvent -= OnDragStartEvent;
            _dragAndDropController.DragEndEvent -= OnDragEndEvent;
            _monoUpdater.UnSubscribe(this);
        }

        private void OnDragStartEvent(ICubeBalanceModel model)
        {
            _isDragging = true;
            _draggedWidget.Setup(model);
            _draggedWidget.gameObject.SetActive(true);
        }

        private void OnDragEndEvent()
        {
            _isDragging = false;
            _draggedWidget.gameObject.SetActive(false);
            _draggedWidget.Setup(null);
        }

        public void OnUpdate()
        {
            if (!_isDragging)
                return;

            var pointerPosition = _inputController.PointerPosition;
            _draggedWidget.transform.position = pointerPosition;
        }
    }
}