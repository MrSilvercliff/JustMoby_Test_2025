using _Project.Scripts.CubeTowerGameScene.Services.Balance;
using _Project.Scripts.CubeTowerGameScene.UI.Windows.Views;
using _Project.Scripts.Project.ObjectPools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.CubeTowerGameScene.UI.Cubes
{
    public class CubeScrollDraggableWidget : CubeWidget, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [Inject] private ICubeTowerGameBalanceService _balanceService;
        [Inject] private IGameDragAndDropController _dragAndDropController;

        private ScrollRect _scrollRect;
        private bool _isDragging;

        public void Setup(ScrollRect scrollRect)
        { 
            _scrollRect = scrollRect;
        }

        public override void OnCreated()
        {
            base.OnCreated();
            _isDragging = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _scrollRect.StopMovement();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _scrollRect.StopMovement();
            _scrollRect.OnBeginDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_isDragging)
                return;

            var yDeltaToStartDrag = _balanceService.CubeDragAndDrop.CubeScrollYDeltaToStartDrag;
            var pointerPosition = eventData.position;
            var yDelta = pointerPosition.y - transform.position.y;

            if (yDelta > yDeltaToStartDrag)
            {
                _scrollRect.OnEndDrag(eventData);
                _scrollRect.StopMovement();
                _dragAndDropController.OnDrag(_balanceModel);
                _isDragging = true;
                return;
            }

            _scrollRect.OnDrag(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (_isDragging)
            {
                _isDragging = false;
                return;
            }

            _scrollRect.OnEndDrag(eventData);
        }

        public class Pool : ProjectMonoMemoryPool<CubeScrollDraggableWidget> { }
    }
}