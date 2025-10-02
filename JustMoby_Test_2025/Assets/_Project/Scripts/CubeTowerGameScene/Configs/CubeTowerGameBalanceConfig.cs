using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.Configs
{
    public interface ICubeTowerGameBalanceConfig
    {
    }

    [CreateAssetMenu(fileName = "CubeTowerGameBalanceConfig", menuName = "Project/Configs/Brick Tower Game/Cube Tower Game Balance Config")]
    public class CubeTowerGameBalanceConfig : ScriptableObject, ICubeTowerGameBalanceConfig
    {

    }
}