using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.Configs
{
    public interface ICubeTowerBuildBalanceConfig
    { 
    }

    [CreateAssetMenu(fileName = "CubeTowerBuildBalanceConfig", menuName = "Project/Configs/Cube Tower Game/Cube Tower Build Balance Config")]
    public class CubeTowerBuildBalanceConfig : ScriptableObject, ICubeTowerBuildBalanceConfig
    {
    }
}