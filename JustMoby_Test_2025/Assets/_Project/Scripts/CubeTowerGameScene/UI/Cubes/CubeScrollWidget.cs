using _Project.Scripts.CubeTowerGameScene.Services.Balance;
using _Project.Scripts.CubeTowerGameScene.Services.ObjectPools;
using _Project.Scripts.Project.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.CubeTowerGameScene.UI.Cubes
{
    public class CubeScrollWidget : MonoBehaviour
    {
        [SerializeField] private GameObject _scrollRectGO;
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private RectTransform _scrollRectContent;
        
        [SerializeField] private GameObject _nonScrollRectGO;
        [SerializeField] private RectTransform _nonScrollContent;

        [SerializeField] private HorizontalLayoutGroup _layout;
        [SerializeField] private RectTransform _prefabTransform;

        [Inject] private ICubeTowerGameBalanceService _balanceService;
        [Inject] private ICubeTowerGameSceneObjectPoolService _objectPoolService;

        private List<CubeWidget> _widgets;

        public void Init()
        {
            _widgets = new();
        }

        public void SpawnCubeWidgets()
        {
            var cubeWidgetPool = _objectPoolService.CubeScrollDraggableWidgetPool;
            var activeBalanceModels = _balanceService.Cubes.GetActiveCubeBalanceModels();

            var scrollNeeded = CheckScrollNeeded(activeBalanceModels.Count);

            _scrollRectGO.SetActive(scrollNeeded);
            _nonScrollRectGO.SetActive(!scrollNeeded);
            var cubeWidgetsContainer = scrollNeeded ? _scrollRectContent : _nonScrollContent;

            foreach (var cubeBalanceModel in activeBalanceModels) 
            {
                var newWidget = cubeWidgetPool.Spawn();
                newWidget.Setup(cubeBalanceModel);
                newWidget.Setup(_scrollRect);
                newWidget.transform.SetParent(cubeWidgetsContainer);
                newWidget.transform.ResetLocalPosition();
                newWidget.transform.ResetLocalRotation();
                newWidget.transform.ResetLocalScale();

                _widgets.Add(newWidget);
            }
        }

        private bool CheckScrollNeeded(int cubesCount)
        {
            var layoutPadding = _layout.padding.left + _layout.padding.right;
            var layoutSpacing = _layout.spacing;
            var prefabWidth = _prefabTransform.rect.width;
            var itemsSumWidth = (prefabWidth * cubesCount) + (layoutSpacing * (cubesCount - 1));
            var sumWidth = itemsSumWidth + layoutPadding;
            var result = sumWidth > _nonScrollContent.rect.width;
            return result;
        }
    }
}