using _Project.Scripts.Project.Configs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.Configs
{
    public interface ICubeTowerGameBalanceConfig
    {
        ICubeBalanceConfig CubeBalanceConfig { get; }
        ICubeDragAndDropBalanceConfig DragAndDropBalanceConfig { get; }
        ICubeTowerBuildBalanceConfig TowerBuildBalanceConfig { get; }
    }

    [CreateAssetMenu(fileName = "CubeTowerGameBalanceConfig", menuName = "Project/Configs/Cube Tower Game/Balance/Cube Tower Game Balance Config")]
    public class CubeTowerGameBalanceConfig : ScriptableObject, ICubeTowerGameBalanceConfig
    {
        public ICubeBalanceConfig CubeBalanceConfig => _cubeBalanceConfig;
        public ICubeDragAndDropBalanceConfig DragAndDropBalanceConfig => _cubeDragAndDropBalanceConfig;
        public ICubeTowerBuildBalanceConfig TowerBuildBalanceConfig => _cubeTowerBuildBalanceConfig;

        [SerializeField] private CubeBalanceConfig _cubeBalanceConfig;
        [SerializeField] private CubeDragAndDropBalanceConfig _cubeDragAndDropBalanceConfig;
        [SerializeField] private CubeTowerBuildBalanceConfig _cubeTowerBuildBalanceConfig;
    }
}