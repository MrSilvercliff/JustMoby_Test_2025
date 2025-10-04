using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.Configs
{
    public interface ICubeTowerBuildBalanceConfig
    { 
        int MaxActiveTowerCount { get; }
    }

    [CreateAssetMenu(fileName = "CubeTowerBuildBalanceConfig", menuName = "Project/Configs/Cube Tower Game/Cube Tower Build Balance Config")]
    public class CubeTowerBuildBalanceConfig : ScriptableObject, ICubeTowerBuildBalanceConfig
    {
        public int MaxActiveTowerCount => _maxActiveTowerCount;

        [SerializeField] private int _maxActiveTowerCount;
    }
}