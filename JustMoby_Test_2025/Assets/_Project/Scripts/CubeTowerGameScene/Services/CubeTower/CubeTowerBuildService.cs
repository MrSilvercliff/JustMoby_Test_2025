using _Project.Scripts.CubeTowerGameScene.Services.Balance;
using _Project.Scripts.CubeTowerGameScene.Services.Balance.Models;
using _Project.Scripts.CubeTowerGameScene.Services.ObjectPools;
using _Project.Scripts.Project.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.CubeTowerGameScene.Services.CubeTower
{
    public interface ICubeTowerBuildService
    {
        bool TryBuildTower(Transform cubeTowerContainer);
    }

    public class CubeTowerBuildService : ICubeTowerBuildService
    {
        [Inject] private ICubeTowerGameBalanceService _balanceService;
        [Inject] private ICubeTowerGameSceneObjectPoolService _objectPoolService;

        [Inject] private ICubeTowerRepository _repository;

        public bool TryBuildTower(Transform cubeTowerContainer)
        {
            var canBuildTower = CanBuildTower();

            if (!canBuildTower)
                return false;

            var cubeTowerPool = _objectPoolService.CubeTowerWidgetPool;
            var cubeTower = cubeTowerPool.Spawn();
            cubeTower.transform.SetParent(cubeTowerContainer);
            cubeTower.transform.ResetLocalPosition();
            cubeTower.transform.ResetLocalRotation();
            cubeTower.transform.ResetLocalZ();
            _repository.Add(cubeTower);
            return true;
        }

        private bool CanBuildTower()
        {
            var activeTowerCount = _repository.Count;
            var maxActiveTowerCount = _balanceService.CubeTowerBuild.MaxActiveTowerCount;
            var result = activeTowerCount >= maxActiveTowerCount;
            return result;
        }
    }
}