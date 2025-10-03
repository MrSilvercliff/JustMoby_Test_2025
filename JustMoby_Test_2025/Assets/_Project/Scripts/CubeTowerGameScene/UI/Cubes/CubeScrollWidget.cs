using _Project.Scripts.CubeTowerGameScene.Services.Balance;
using _Project.Scripts.CubeTowerGameScene.Services.ObjectPools;
using _Project.Scripts.Project.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.CubeTowerGameScene.UI.Cubes
{
    public class CubeScrollWidget : MonoBehaviour
    {
        [SerializeField] private Transform _scrollViewContent;

        [Inject] private ICubeTowerGameBalanceService _balanceService;
        [Inject] private ICubeTowerGameSceneObjectPoolService _objectPoolService;

        private List<CubeWidget> _widgets;

        public void Init()
        {
            _widgets = new();
        }

        public void SpawnCubeWidgets()
        {
            var cubeWidgetPool = _objectPoolService.CubeWidgetPool;
            var activeBalanceModels = _balanceService.Cubes.GetActiveCubeBalanceModels();

            foreach (var cubeBalanceModel in activeBalanceModels) 
            {
                var newWidget = cubeWidgetPool.Spawn();
                newWidget.Setup(cubeBalanceModel);
                newWidget.transform.SetParent(_scrollViewContent);
                newWidget.transform.ResetLocalPosition();
                newWidget.transform.ResetLocalRotation();
                newWidget.transform.ResetLocalScale();

                _widgets.Add(newWidget);
            }
        }
    }
}