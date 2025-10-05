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
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private RectTransform _draggableObject;
        [SerializeField] private CubeWidget _draggedWidget;

        [Inject] private IInputController _inputController;
        [Inject] private IGameDragAndDropController _dragAndDropController;
        [Inject] private IMonoUpdater _monoUpdater;

        private Vector2 _offsetMultiplier;
        private bool _isDragging;

        public void Init()
        {
            var screen = new Vector2(Screen.width, Screen.height);
            _offsetMultiplier = new Vector2(_rectTransform.rect.width / screen.x, _rectTransform.rect.height / screen.y);
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
            var anchoredPosition = new Vector2(pointerPosition.x * _offsetMultiplier.x, pointerPosition.y * _offsetMultiplier.y);
            _draggableObject.anchoredPosition = anchoredPosition;
        }
    }
}