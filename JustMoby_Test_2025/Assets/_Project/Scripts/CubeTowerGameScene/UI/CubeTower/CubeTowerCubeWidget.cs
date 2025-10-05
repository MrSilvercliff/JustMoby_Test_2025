using _Project.Scripts.CubeTowerGameScene.Services.Balance;
using _Project.Scripts.CubeTowerGameScene.Services.Balance.Models;
using _Project.Scripts.CubeTowerGameScene.UI.Cubes;
using _Project.Scripts.CubeTowerGameScene.UI.Windows.Views;
using _Project.Scripts.Project.ObjectPools;
using _Project.Scripts.Project.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;
using ZerglingUnityPlugins.Tools.Scripts.Components;

namespace _Project.Scripts.CubeTowerGameScene.UI.CubeTower
{
    public class CubeTowerCubeWidget : CubeWidget, IDragHandler, IDropHandler, IEndDragHandler
    {
        public ICubeBalanceModel BalanceModel => _balanceModel;

        [SerializeField] private Image _dragStateImage;
        [SerializeField] private UnityEventContainer _onBeginDragEvent;
        [SerializeField] private UnityEventContainer _onEndDragEvent;

        [Inject] private ICubeTowerGameBalanceService _balanceService;
        [Inject] private IGameDragAndDropController _dragAndDropController;

        private bool _isDragging;

        protected override void OnRefreshNull()
        {
            base.OnRefreshNull();
            _dragStateImage.sprite = null;
        }

        protected override void OnRefreshNotNull()
        {
            base.OnRefreshNotNull();
            _dragStateImage.sprite = _balanceModel.Sprite;
        }

        public override void OnCreated()
        {
            base.OnCreated();
            _isDragging = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_isDragging)
                return;

            if (eventData.delta.sqrMagnitude < _balanceService.CubeDragAndDrop.CubeTowerDeltaToStartDragSquared)
                return;

            _isDragging = true;
            _onBeginDragEvent.Event?.Invoke();
        }

        public void OnDrop(PointerEventData eventData)
        {
            _isDragging = false;
            _onEndDragEvent.Event?.Invoke();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _isDragging = false;
            _onEndDragEvent.Event?.Invoke();
        }

        public class Pool : ProjectMonoMemoryPool<CubeTowerCubeWidget> { }
    }
}