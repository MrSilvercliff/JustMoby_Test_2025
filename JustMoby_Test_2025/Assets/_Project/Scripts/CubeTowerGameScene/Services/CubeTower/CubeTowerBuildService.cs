using _Project.Scripts.CubeTowerGameScene.Services.Balance;
using _Project.Scripts.CubeTowerGameScene.Services.Balance.Models;
using _Project.Scripts.CubeTowerGameScene.Services.ObjectPools;
using _Project.Scripts.CubeTowerGameScene.UI.CubeTower;
using _Project.Scripts.Project.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.CubeTowerGameScene.Services.CubeTower
{
    public interface ICubeTowerBuildService
    {
        bool TryBuildTower(Transform cubeTowerContainer, out ICubeTowerWidget cubeTowerWidget);
    }

    public class CubeTowerBuildService : ICubeTowerBuildService
    {
        [Inject] private ICubeTowerGameBalanceService _balanceService;
        [Inject] private ICubeTowerGameSceneObjectPoolService _objectPoolService;

        [Inject] private ICubeTowerRepository _repository;

        public bool TryBuildTower(Transform cubeTowerContainer, out ICubeTowerWidget cubeTowerWidget)
        {
            var canBuildTower = CanBuildTower();

            if (!canBuildTower)
            {
                cubeTowerWidget = null;
                return false;
            }

            var cubeTowerPool = _objectPoolService.CubeTowerWidgetPool;
            var cubeTower = cubeTowerPool.Spawn();
            cubeTower.transform.SetParent(cubeTowerContainer);
            cubeTower.transform.ResetLocalPosition();
            cubeTower.transform.ResetLocalRotation();
            cubeTower.transform.ResetLocalScale();
            cubeTower.SetActive(true);
            _repository.Add(cubeTower);
            cubeTowerWidget = cubeTower;
            return true;
        }

        private bool CanBuildTower()
        {
            var activeTowerCount = _repository.Count;
            var maxActiveTowerCount = _balanceService.CubeTowerBuild.MaxActiveTowerCount;
            var result = activeTowerCount < maxActiveTowerCount;
            return result;
        }
    }
}