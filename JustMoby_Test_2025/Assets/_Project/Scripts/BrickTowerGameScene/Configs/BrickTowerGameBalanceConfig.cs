using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.BrickTowerGameScene.Configs
{
    public interface IBrickTowerGameBalanceConfig
    { 
    }

    [CreateAssetMenu(fileName = "BrickTowerGameBalanceConfig", menuName = "Project/Configs/Brick Tower Game/Brick Tower Game Balance Config")]
    public class BrickTowerGameBalanceConfig : ScriptableObject, IBrickTowerGameBalanceConfig
    {

    }
}