using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.Configs
{
    public interface ICubeDragAndDropBalanceConfig
    { 
        float CubeScrollPointerYDeltaToStartDrag { get; }
        float CubeTowerDeltaToStartDrag { get; }
    }

    [CreateAssetMenu(fileName = "CubeDragAndDropBalanceConfig", menuName = "Project/Configs/Cube Tower Game/Cube Drag And Drop Balance Config")]
    public class CubeDragAndDropBalanceConfig : ScriptableObject, ICubeDragAndDropBalanceConfig
    {
        public float CubeScrollPointerYDeltaToStartDrag => _cubeScrollPointerYDeltaToStartDrag;
        public float CubeTowerDeltaToStartDrag => _cubeTowerDeltaToStartDrag;

        [SerializeField] private float _cubeScrollPointerYDeltaToStartDrag;
        [SerializeField] private float _cubeTowerDeltaToStartDrag;
    }
}