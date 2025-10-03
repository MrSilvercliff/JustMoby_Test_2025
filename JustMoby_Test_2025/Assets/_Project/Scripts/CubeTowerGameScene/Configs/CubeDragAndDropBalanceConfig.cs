using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.Configs
{
    public interface ICubeDragAndDropBalanceConfig
    { 
        float PointerYDeltaToStartDrag { get; }
    }

    [CreateAssetMenu(fileName = "CubeDragAndDropBalanceConfig", menuName = "Project/Configs/Cube Tower Game/Cube Drag And Drop Balance Config")]
    public class CubeDragAndDropBalanceConfig : ScriptableObject, ICubeDragAndDropBalanceConfig
    {
        public float PointerYDeltaToStartDrag => _pointerYDeltaToStartDrag;

        [SerializeField] private float _pointerYDeltaToStartDrag;
    }
}